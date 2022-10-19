using Npgsql;
namespace Assignment;

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


/*var cs = "Host=localhost;Username=Turid;Password=s$cret;Database=Assignment4-BDSA";

using var con = new NpgsqlConnection(cs);
con.Open();

var sql = "SELECT version()";

using var cmd = new NpgsqlCommand(sql, con);

var version = cmd.ExecuteScalar().ToString();
Console.WriteLine($"PostgreSQL version: {version}");*/

public class Program
{
    public static void Main (string[] args)
    {
        
    }
    

    /*public void ConfigureServices(IServiceCollection services)
    {
        // Other DI initializations

        services.AddDbContext<BloggingContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("BloggingContext")));
    }*/
}