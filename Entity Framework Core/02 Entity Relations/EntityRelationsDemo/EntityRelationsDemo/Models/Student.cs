namespace EntityRelationsDemo.Models
{
    internal class Student
    {
        public Student()
        {
            this.StudentCourses = new HashSet<StudentCourse>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public Town? CurrentResidence { get; set; }
        public Town? PlaceOfBirth { get; set; }


        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
