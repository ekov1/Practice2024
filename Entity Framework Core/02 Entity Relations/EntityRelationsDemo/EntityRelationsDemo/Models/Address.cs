namespace EntityRelationsDemo.Models
{
    internal class Address
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
