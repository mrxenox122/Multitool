using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CFV.Multitool.BL
{
    class CriticalHitEffect
    {
        public string name {get; set;}
        public string desc { get; set; }

        public CriticalHitEffect ()
        {

        }
    }
    class CriticalHitList : List<CriticalHitEffect>
    {

    }
}
