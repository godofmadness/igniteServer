using System;
using System.Collections.Generic;
using System.Text;
using Ignite.src.core.networkentities;
using Ignite.src.core.config;
using Ignite.src.core.fs;
using System.Threading.Tasks;
using System.IO;
using Ignite.src.core.logger;

namespace Ignite.src.core.engine.proccessor {



    class StaticHttpProccessor : Proccessor {


        private static String STATIC_DIR_PROP_NAME = "staticDir";
        private static String DEFAULT_PATH = "/index.html";
        private static String DEFAULT_EXTENSION = ".html";

        private IgniteLogger logger = new IgniteLogger();

        // static http request proccessing logic
        public async Task<IgniteResponse> proccess(IgniteRequest request)  {

            // get resource name from route
            String route = request.getRoute();

            String[] routePath = route.Split("/");
            if (route == "/") {
                logger.debug("StaticHttpProccessor@proccess | default route, servinc default page {0}", DEFAULT_PATH);
                route = DEFAULT_PATH;

            } else if (routePath[routePath.Length - 1].Split(".").Length == 1) {
                // if last path part don't have extension add default
                logger.debug("StaticHttpProccessor@proccess | no extension, adding default", DEFAULT_EXTENSION);
                route = route + DEFAULT_EXTENSION;
            }

            // reverse slashes ;)
            route = route.Replace("/", "\\");
            logger.info("StaticHttpProccessor@proccess | route {0}", route);

            // get configured working directory from configuration file
            ConfigurationService configService = await ConfigurationService.getInstance();
            IgniteConfiguration config = configService.getCoreServerConfig();
            //Console.WriteLine("StaticHttpProccessor@proccess | config {0}", config);
            String staticDataDir = config.getProperty(STATIC_DIR_PROP_NAME);

            // get file by filename
            try {
                var file = await FileSystemService.readFullFile(staticDataDir + route);
                logger.debug("StatichttpProccessor@proccess | file finded", file);
                IgniteResponse response = IgniteResponseFactory.getInstance();
                response.setBody(file);

                // set MIME TYPE
                String MIME = MIMEType.getMIMETypeByExtension(getFileExtensionByRoute(route));
                response.getHeaders()[HttpHeaders.ContentLength] = " " + file.Length.ToString();
                response.getHeaders()[HttpHeaders.ContentType] = " " + MIME; 

                return response;

            } catch (FileNotFoundException e) {
                logger.warn("StaticHttpProccessor@proccess | no file finded by path {0}, reutning 404", staticDataDir + route);
                return IgniteResponseFactory.getInstance(new IgniteResponseStatus(HttpStatus.NOT_FOUND, HttpStatus.NOT_FOUND_MESSAGE));
            }
        }


        private String getFileExtensionByRoute(String route) {
            String[] routePath = route.Split("\\");
            String[] filePath = routePath[routePath.Length - 1].Split(".");

            return filePath[filePath.Length - 1];
        }


    }
}
