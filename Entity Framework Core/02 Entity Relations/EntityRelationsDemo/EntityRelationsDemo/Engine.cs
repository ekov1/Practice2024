using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelationsDemo
{
    internal class Engine
    {
        public int Id { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<Bus> Bus { get; set; }

    }
}
