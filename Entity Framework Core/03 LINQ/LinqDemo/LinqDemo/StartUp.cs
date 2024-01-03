using LinqDemo.Data;
using Microsoft.EntityFrameworkCore;

using (SoftUniContext context = new SoftUniContext())
{
    var employees = await context.Employees
        .Where(e => e.ManagerId == 185)
        .Include(e => e.Manager)
        .ToListAsync();


    foreach (var e in employees)
    {
        Console.WriteLine($"{e.FirstName} {e.LastName}, Manager: {e.Manager?.FirstName} {e.Manager?.LastName}");
    }
    Console.WriteLine();

    var queryStr = context.Employees
        .Where(e => e.ManagerId == 185)
        .Include(e => e.Manager)
        .ToQueryString();

    Console.WriteLine(queryStr);
}

Console.WriteLine("///////////////////////////////");

using (SoftUniContext context = new SoftUniContext())
{
    var employees = await context.Employees
        .Where(e => e.ManagerId == 185)
        .Select(e => new
        {
            FirstName = e.FirstName,
            LastName = e.LastName
        })
        .ToListAsync();


    foreach (var e in employees)
    {
        Console.WriteLine($"{e.FirstName} {e.LastName}");
    }
    Console.WriteLine();
    var queryStr = context.Employees
        .Where(e => e.ManagerId == 185)
        .Select(e => new
        {
            FirstName = e.FirstName,
            LastName = e.LastName
        })
        .ToQueryString();

    Console.WriteLine(queryStr);
}


Console.WriteLine("///////////////////////////////");

using (SoftUniContext context = new SoftUniContext())
{
    var employees = await context.Employees
        .Where(e => e.ManagerId == 185)
        .Select(e => new
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            Manager = e.Manager
        })
        .ToListAsync();


    foreach (var e in employees)
    {
        Console.WriteLine($"{e.FirstName} {e.LastName}, Manager: {e.Manager?.FirstName} {e.Manager?.LastName}");

    }
    Console.WriteLine();
    var queryStr = context.Employees
        .Where(e => e.ManagerId == 185)
        .Select(e => new
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            Manger = e.Manager
        })
        .ToQueryString();

    Console.WriteLine(queryStr);
}

Console.WriteLine("///////////////////////////////");

using (SoftUniContext context = new SoftUniContext())
{
    var employees = context.Employees
        .Join(context.Departments, e => e.DepartmentId, d => d.DepartmentId, (e, d) => new
        {
            e.FirstName,
            e.LastName,
            d.Name
        }).ToListAsync();
}
