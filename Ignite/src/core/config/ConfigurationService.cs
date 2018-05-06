using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ignite.src.core.fs;

namespace Ignite.src.core.config
{



    class ConfigurationService {

        private static ConfigurationService selfRef;
        // path to config file from builder folder;
        private static String CONFIG_FILE_PATH = "../../../src/core/server.config.properties";


        private IgniteConfiguration config;

        public async static Task<ConfigurationService> getInstance() {

            if (selfRef == null) {
                var config = await createConfig();
                selfRef = new ConfigurationService(config);
            }

            return selfRef;
        }


        private ConfigurationService(IgniteConfiguration config) {
            this.config = config;
        }

        public IgniteConfiguration getCoreServerConfig() {
            return config;
        }


        public static async Task<IgniteConfiguration> createConfig() {
            IgniteConfiguration serverConfiguration = new IgniteConfiguration();


            List<String> config = await FileSystemService.readLines(CONFIG_FILE_PATH);
  

            foreach (var line in config) {
                String[] kv = line.Split("=");
                Console.Write("key {0}", kv[0]);
                Console.Write("value {0}", kv[1]);
                serverConfiguration.setProperty(kv[0], kv[1]);
            }

            return serverConfiguration;
        }

    }
}
