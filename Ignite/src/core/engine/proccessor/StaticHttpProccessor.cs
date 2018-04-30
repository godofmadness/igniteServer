using System;
using System.Collections.Generic;
using System.Text;
using Ignite.src.core.networkentities;

namespace Ignite.src.core.engine.proccessor {


    class StaticHttpProccessor : Proccessor {

        // static http request proccessing logic
        public IgniteResponse proccess(IgniteRequest request)  {

            // get resource name from route

            // get configured working directory from configuration file

            // get file by filename

            // set response


            return IgniteResponseFactory.getInstance();
        }
    }
}
