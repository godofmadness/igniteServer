using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ignite.src.core.networkentities;

namespace Ignite.src.core.engine.proccessor
{
    interface Proccessor
    {


        Task<IgniteResponse> proccess(IgniteRequest request);
    }
}
