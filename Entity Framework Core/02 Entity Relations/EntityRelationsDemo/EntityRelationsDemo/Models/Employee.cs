﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelationsDemo.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DeparmentId { get; set; }
        public Department Department { get; set; }
    }
}
