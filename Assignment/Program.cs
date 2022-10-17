using Npgsql;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var cs = "Host=localhost;Username=postgres;Password=s$cret;Database=Assignment4-BDSA";

using var con = new NpgsqlConnection(cs);
con.Open();

var sql = "SELECT version()";

using var cmd = new NpgsqlCommand(sql, con);

var version = cmd.ExecuteScalar().ToString();
Console.WriteLine($"PostgreSQL version: {version}");