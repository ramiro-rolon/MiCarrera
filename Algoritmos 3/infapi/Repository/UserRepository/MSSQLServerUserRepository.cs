using ConAPI.Domain;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ConAPI.Repositories;

public class MSSQLServerUserRepository : IUserRepository
{
    private string _connectionString;

    public MSSQLServerUserRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("MSSQL")
            ?? throw new InvalidOperationException("Connection string 'MSSQL Server' no configurada.");
    }

    public async Task<int> CreateUser(User usr)
    {
        const string sql = """
            INSERT INTO "User" 
            (name, last_name, user_name, role, password)
            VALUES
            (@name, @last_name, @user_name, @role, @password);
            SELECT SCOPE_IDENTITY();
        """;

        using var conn = new SqlConnection(this._connectionString);
        return await conn.QuerySingleAsync<int>(sql, usr);
    }
}