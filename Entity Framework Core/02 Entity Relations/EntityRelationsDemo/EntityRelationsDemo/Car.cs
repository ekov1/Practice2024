using System.ComponentModel.DataAnnotations.Schema;

namespace EntityRelationsDemo
{
    internal class Car
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public int InProjectOnly { get; set; }

        [ForeignKey(nameof(CustomEngineId))]
        public int CustomEngineId { get; set; }
        public Engine CustomEngine { get; set; }
    }
}
