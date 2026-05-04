using Dapper;
using ApiPract.Domain;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;

namespace ApiPract.Repository;

public class MSSQLUsuarioRepositorio : IUsuarioRepositorio{
    private string _connectionString;

    public MSSQLUsuarioRepositorio(IConfiguration config){
        _connectionString = config.GetConnectionString("MSSQL")
            ?? throw new InvalidOperationException("ERROR AGUEVO");
    }

    public async Task<IEnumerable<Usuario>> GetUsuarios(){
        const string sql = """
            SELECT * FROM usuarios;
        """; 

        using var conn = new SqlConnection(this._connectionString);
        return await conn.QueryAsync<Usuario>(sql);
    }

    public async Task<int> InsertUsuarios(Usuario usuario){
        const string sql = """
            INSERT INTO Usuarios ("nombre", "email", "Contrasena") 
            VALUES(@nombre, @mail, @pass);
            SELECT SCOPE_IDENTITY();
        """;

        using var conn = new SqlConnection(this._connectionString);
        return await conn.QuerySingleAsync<int>(sql, usuario);
    }

    public async Task<IEnumerable<Usuario>> DeleteUsuarios(int usuario){
        const string sql = """
            DELETE FROM usuarios WHERE id = @id;
        """;

        using var conn = new SqlConnection(this._connectionString);
        return await conn.QueryAsync<Usuario>(sql, new { id = usuario });
    }

}