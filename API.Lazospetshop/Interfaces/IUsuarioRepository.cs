using API.Lazospetshop.Models.TUsuario;

namespace API.Lazospetshop.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioRespuesta>> ObtenerTodos();
        Task<UsuarioRespuesta> ObtenerPorId(int id);
        Task<UsuarioRespuesta> ObtenerPorCorreo(string correo);
        Task<bool> Registrar(UsuarioRegistrar usuario);
        Task<UsuarioRespuesta> Login(UsuarioLogin usuarioLogin);
        Task<bool> CambiarContrasena(UsuarioCambiarPass usuarioCambiarPass);
    }
}
