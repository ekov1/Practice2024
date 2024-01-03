using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelationsDemo.Models
{
    internal class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("CurrentResidence")]
        public ICollection<Student> CurrentResidences { get; set; }

        [InverseProperty("PlaceOfBirth")]
        public ICollection<Student> PlaceOfBirths { get; set; }

    }
}
