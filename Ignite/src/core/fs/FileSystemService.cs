using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Ignite.src.core.fs
{
    class FileSystemService {


        public static async Task<List<String>> readLines(String filename) {

            var lines = new List<String>();

            using (var reader = File.OpenText(filename)) {
                string line;

                while ((line = await reader.ReadLineAsync()) != null) {
                    lines.Add(line);
                }


                return lines;
            }
        }


        public static async Task<String> readFullFile(String filename) {

            String file;
            using (var reader = File.OpenText(filename)) {
                file = await reader.ReadToEndAsync();
            }

            return file;
        }
    }
}
