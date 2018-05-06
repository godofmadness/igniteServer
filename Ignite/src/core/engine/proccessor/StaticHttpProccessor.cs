using System;
using System.Collections.Generic;
using System.Text;
using Ignite.src.core.networkentities;
using Ignite.src.core.config;
using Ignite.src.core.fs;
using System.Threading.Tasks;
using System.IO;

namespace Ignite.src.core.engine.proccessor {



    class StaticHttpProccessor : Proccessor {


        private static String STATIC_DIR_PROP_NAME = "staticDir";
        private static String DEFAULT_PATH = "/index.html";
        private static String DEFAULT_EXTENSION = ".html";

        // static http request proccessing logic
        public async Task<IgniteResponse> proccess(IgniteRequest request)  {

            // get resource name from route
            String route = request.getRoute();

            String[] routePath = route.Split("/");
            if (route == "/") {
                Console.WriteLine("StaticHttpProccessor@proccess | default route, servinc default page {0}", DEFAULT_PATH);
                route = DEFAULT_PATH;

            } else if (routePath[routePath.Length - 1].Split(".").Length == 1) {
                // if last path part don't have extension add default
                Console.WriteLine("StaticHttpProccessor@proccess | no extension, adding default", DEFAULT_EXTENSION);
                route = route + DEFAULT_EXTENSION;
            }


            // reverse slashes ;)
            route = route.Replace("/", "\\");
            Console.WriteLine("StaticHttpProccessor@proccess | route {0}", route);

            
            // get configured working directory from configuration file
            ConfigurationService configService = await ConfigurationService.getInstance();
            IgniteConfiguration config = configService.getCoreServerConfig();
            Console.WriteLine("StaticHttpProccessor@proccess | config {0}", config);
            String staticDataDir = config.getProperty(STATIC_DIR_PROP_NAME);

            // get file by filename
            try {
                var file = await FileSystemService.readFullFile(staticDataDir + route);
                Console.WriteLine("StatichttpProccessor@proccess | file finded", file);
                IgniteResponse response = IgniteResponseFactory.getInstance();
                response.setBody(file);

                // set MIME TYPE
                String MIME = MIMEType.getMIMETypeByExtension(getFileExtensionByRoute(route));
                response.getHeaders()[HttpHeaders.ContentType] = MIME; 

                return response;

            } catch (FileNotFoundException e) {
                Console.WriteLine("StaticHttpProccessor@proccess | no file finded by path {0}, reutning 404", staticDataDir + route);
                return IgniteResponseFactory.getInstance(new IgniteResponseStatus(HttpStatus.NOT_FOUND, HttpStatus.NOT_FOUND_MESSAGE));
            }

            // TODO MIME type mapping 


            // set response
        }


        private String getFileExtensionByRoute(String route) {
            String[] routePath = route.Split("\\");
            String[] filePath = routePath[routePath.Length - 1].Split(".");

            return filePath[filePath.Length - 1];
        }


    }
}
