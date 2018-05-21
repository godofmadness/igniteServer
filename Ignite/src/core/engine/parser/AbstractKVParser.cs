using System;
using System.Collections.Generic;
using System.Text;
using static System.Collections.Generic.Dictionary<string, string>;

namespace Ignite.src.core.engine.parser
{
    abstract class AbstractKVParser
    {


        public Dictionary<String, String> Parse(String rawBody) {

            var container = GetContainer();
            if (rawBody.Length == 0) { 
                return container;
            }

            String[] bodyKV = rawBody.Split(GetMainDelimeter());
 
            for (int i = 0; i < bodyKV.Length; i++) {
                
                String[] kv = bodyKV[i].Split(GetKVDelimeter());


                container.Add(kv[0], kv[1]);
            }

            return container;
        }

        public String stringify(Dictionary<String, String> container) {
            StringBuilder stringifiedContainer = new StringBuilder();
            foreach(KeyValuePair<String, String> entry in container) {
                stringifiedContainer.Append(entry.Key + GetKVDelimeter() + entry.Value);
                stringifiedContainer.Append(GetMainDelimeter());
            }

            return stringifiedContainer.ToString();
        }

        public abstract String GetMainDelimeter();
        public abstract String GetKVDelimeter();
        public abstract Dictionary<String, String> GetContainer();


    }
}
