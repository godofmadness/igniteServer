using System;
using System.Collections.Generic;
using System.Text;
using Ignite.src.core.networkentities;

namespace Ignite.src.core.engine.proccessor
{
    interface Proccessor
    {

        IgniteResponse proccess(IgniteRequest request);
    }
}
