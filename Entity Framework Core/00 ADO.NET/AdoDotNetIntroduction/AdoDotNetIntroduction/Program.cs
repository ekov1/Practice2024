using Microsoft.Data.SqlClient;
SqlConnection connection = new SqlConnection("Server=.;Database=SoftUni;Trusted_Connection=True;TrustServerCertificate=True;") ;

connection.Open();
using (connection)
{
    SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM [SoftUni].[dbo].[Employees]", connection);
    int employeesCount = (int) sqlCommand.ExecuteScalar();
    Console.WriteLine($"Employees count: {employeesCount}");
}

connection.ConnectionString = "Server=.;Database=SoftUni;Trusted_Connection=True;TrustServerCertificate=True;";
connection.Open();
using (connection)
{
    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [SoftUni].[dbo].[Employees]", connection);
    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

    using (reader)
    {
        while (reader.Read())
        {
            string firstName = (string)reader["FirstName"];
            string lastName = (string)reader["LastName"];
            decimal salary = (decimal)reader["Salary"];

            Console.WriteLine($"{firstName} {lastName} salary : {salary}");
        }
    }

}