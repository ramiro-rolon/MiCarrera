using ConAPI.Domain;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ConAPI.Repositories;

public class MSSQLSimpleObjectRepository : ISimpleObjectRepository
{
    private string _connectionString;

    public MSSQLSimpleObjectRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("MSSQL")
            ?? throw new InvalidOperationException("Connection string 'MSSQL Server' no configurada.");
    }

    public async Task<IEnumerable<SimpleObject>> GetObjects()
    {
        const string sql = """
            SELECT * FROM SimpleObject;
        """;

        using var conn = new SqlConnection(this._connectionString);
        return await conn.QueryAsync<SimpleObject>(sql);
    }

    public async Task<int> InsertObject(SimpleObject simpleObject)
    {
        const string sql = """
            INSERT INTO SimpleObject ("number", "name") VALUES (@number, @name);
            SELECT SCOPE_IDENTITY();
        """;

        using var conn = new SqlConnection(this._connectionString);
        return await conn.ExecuteAsync(sql, new {simpleObject.number, simpleObject.name});
    }
}