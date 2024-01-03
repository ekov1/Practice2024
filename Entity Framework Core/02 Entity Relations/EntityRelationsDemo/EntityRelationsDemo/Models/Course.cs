namespace EntityRelationsDemo.Models
{
    internal class Course
    {
        public Course()
        {
            this.StudentCourses = new HashSet<StudentCourse>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
