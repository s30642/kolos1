using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace Tutorial9.Services;

public class DbService : IDbService
{
    private readonly IConfiguration _configuration;
    public DbService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task DoSomethingAsync(int clientID)
    {
        var query =
            @"SELECT v.date, c.first_name, c.last_name, c.date_of_birth, m.mechanic_id, m.licence_number
            FROM Visit v
            JOIN Client c ON v.client_id = c.client_id
            JOIN Mechanic m ON v.mechanic_id = m.mechanic_id
            WHERE v.client = @clientId;";

        await using SqlConnection connection = new SqlConnection(_connectionString);
        await using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = query;
        await connection.OpenAsync();

        command.Parameters.AddWithValue("@clientId", clientID);
        command.ExecuteNonQuery();
    }

    public async Task DoSomethingAsync1()
    {
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        await using SqlCommand command = new SqlCommand();
        
        command.Connection = connection;
        await connection.OpenAsync();
        
        command.CommandText = "NazwaProcedury";
        command.CommandType = CommandType.StoredProcedure;
        
        command.Parameters.AddWithValue("@Id", 2);
        
        await command.ExecuteNonQueryAsync();
    }
}