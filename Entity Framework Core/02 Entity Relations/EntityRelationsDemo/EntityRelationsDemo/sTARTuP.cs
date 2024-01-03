using EntityRelationsDemo.Models;

namespace EntityRelationsDemo
{
    internal class sTARTuP
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();

            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            Department sales = new Department()
            {
                Name = "Sales"
            };

            Employee ivan = new Employee()
            {
                Name = "Ivan",
                Department = sales
            };

            context.Employees.Add(ivan);

            Employee petar = new Employee()
            {
                Name = "Petar"
            };

            Department marketing = new Department()
            {
                Name = "Marketing"
            };

            marketing.Employees.Add(petar);

            context.Departments.Add(marketing);


            //////////////////////////////////////

            Student student = new Student()
            {
                Name = "Ivan"
            };

            Course oop = new Course()
            {
                Name = "OOP"
            };

            student.StudentCourses.Add(new StudentCourse()
            {
                Course = oop
            });

            context.Students.Add(student);

            context.SaveChanges();
        }
    }
}