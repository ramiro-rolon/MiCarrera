using ApiPract.Domain;

namespace ApiPract.Repository;

public interface IUsuarioRepositorio{
    Task <IEnumerable<Usuario>> GetUsuarios();
    Task <int> InsertUsuarios(Usuario usuario);
    //Task <IEnumerable<Usuario>> DeleteUsuarios();
    // Task <IEnumerable<Usuario>> UpdateUsuarios();
}