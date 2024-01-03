using EFScafolding.Data;
using EFScafolding.Models;
using Microsoft.EntityFrameworkCore;

using (SoftUniContext context = new SoftUniContext())
{
    Console.WriteLine(5 % 2);
    Console.WriteLine(5 / 2);


    DateTime oldEmployeesDate = new DateTime(2000, 1, 1);
    List<Employee> employees = await context.Employees
        .Where(e => e.HireDate < oldEmployeesDate)
        .ToListAsync();

    foreach (var employee in employees)
    {
        Console.WriteLine($"{employee.FirstName} {employee.LastName}");
    }

    var person = await context.Employees.FindAsync(30);

    Console.WriteLine($"{person.FirstName} {person.LastName}");

    var richBoy = await context.Employees
         .AsNoTracking()
         .OrderByDescending(e => e.Salary)
         .Select(e => new
         {
             FirstName = e.FirstName,
             LastName = e.LastName,
             Salary = e.Salary
         }).FirstOrDefaultAsync();

    Console.WriteLine($"{richBoy.FirstName} {richBoy.LastName}: {richBoy.Salary}");

    int employeeCount = await context.Employees.CountAsync();
    int pageLength = 10;
    int pages = employeeCount / pageLength;
    int reminder = employeeCount % pageLength;
    if (reminder > 0)
    {
        pages++;
    }

    for (int i = 0; i < pages; i++)
    {
        var page = await context.Employees
             .AsNoTracking()
             .OrderBy(e => e.FirstName)
             .ThenBy(e => e.LastName)
             .Select(e => new
             {
                 FirstName = e.FirstName,
                 LastName = e.LastName,
                 Salary = e.Salary
             }).Skip(i * pageLength)
             .Take(pageLength)
             .ToListAsync();

        foreach (var e in page)
        {
            Console.WriteLine($"{e.FirstName} {e.LastName}: {e.Salary}");
        }
        Console.WriteLine();
    }


    for (int i = 0; i < pages; i++)
    {
        var query = context.Employees
             .AsNoTracking()
             .OrderBy(e => e.FirstName)
             .ThenBy(e => e.LastName)
             .Select(e => new
             {
                 FirstName = e.FirstName,
                 LastName = e.LastName,
                 Salary = e.Salary
             }).Skip(i * pageLength)
             .Take(pageLength)
             .ToQueryString();


        Console.WriteLine(query);
        Console.WriteLine();
    }

    await context.Projects
         .AddAsync(new Project()
         {
             Name = "The new Name 1",
             StartDate = DateTime.Today,
         });

    await context.SaveChangesAsync();

    var project = await context.Projects
        .FirstOrDefaultAsync(p => p.Name == "The new Name 1");

    if (project != null)
    {
        project.Name = "Updated name 1";
    }

    await context.SaveChangesAsync();

    project = await context.Projects
       .FirstOrDefaultAsync(p => p.Name == "Updated name 1");

    if (project != null)
    {
        context.Projects
             .Remove(project);
    }

    await context.SaveChangesAsync();

}
