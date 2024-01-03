using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelationsDemo
{
    internal class Bus
    {
        public int License { get; set; }
        public int Region { get; set; }
        public string? Info { get; set; }

        public int EngineId { get; set; }
        public Engine Engine { get; set; }
    }
}
