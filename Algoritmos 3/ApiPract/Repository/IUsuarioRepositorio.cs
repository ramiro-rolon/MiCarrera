using System.Runtime.InteropServices;
using ApiPract.Domain;

namespace ApiPract.Repository;

public interface IUsuarioRepositorio{
    Task <IEnumerable<Usuario>> GetUsuarios();
    Task <int> InsertUsuarios(Usuario usuario);
    Task <IEnumerable<Usuario>> DeleteUsuarios(int usuario);
    // Task <IEnumerable<Usuario>> UpdateUsuarios();
}