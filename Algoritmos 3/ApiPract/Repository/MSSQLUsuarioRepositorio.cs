using Dapper;
using ApiPract.Domain;
using Microsoft.Data.sql;

namespace ApiPract.Repository;

public class MSSQLSimpleObjectRepository : IUsuarioRepositorio{
    private string _connectionString;

    public MSSQLSimpleObjectRepository(IConfiguration config){
        _connectionString = config.GetConnectionString("MSSQL");
        ?? throw new InvalidOperationException("ERROR AGUEVO");
    }

    public async Task<IEnumerable<Usuario>> GetUsuarios(){
        const string sql = """
            SELECT * FROM usuarios;
        """;

        using var conn = new SqlConnection(this._connectionString);
        return await conn.QueryAsync<SimpleObject>(sql);
    }

    public async Task<int> InsertUsuarios(Usuario usuario){
        const string sql = """
            INSERT INTO Usuarios ("nombre", "email", "pass") 
            VALUES(@nombre, @mail, @pass);
            SELECT SCOPE_IDENTITY();
        """;

        using var conn = new SqlConnection(this._connectionString);
        return await conn.QuerySingleAsync(sql, usuario);
    }

}