using API.Lazospetshop.Data;
using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TUsuario;
using Microsoft.EntityFrameworkCore;

namespace API.Lazospetshop.Services
{
    public class UsuarioService : IUsuarioRepository
    {
        private readonly ApplicationContext _context;
        private readonly IImageRepository _imageRepository;

        public UsuarioService(ApplicationContext context, IImageRepository imageRepository)
        {
            _context = context;
            _imageRepository = imageRepository;
        }

        public async Task<IEnumerable<UsuarioRespuesta>> ObtenerTodos()
        {
            var usuarios = await _context.Usuario
                .Include(u => u.TipoDocumento)
                .Include(u => u.Genero)
                .ToListAsync();

            return usuarios.Select(MapUsuarioToUsuarioRespuesta);
        }

        public async Task<UsuarioRespuesta> ObtenerPorId(int id)
        {
            var usuario = await _context.Usuario
                .Include(u => u.TipoDocumento)
                .Include(u => u.Genero)
                .FirstOrDefaultAsync(u => u.Id == id);

            return usuario != null ? MapUsuarioToUsuarioRespuesta(usuario) : null;
        }

        public async Task<UsuarioRespuesta> ObtenerPorCorreo(string correo)
        {
            var usuario = await _context.Usuario
                .Include(u => u.TipoDocumento)
                .Include(u => u.Genero)
                .FirstOrDefaultAsync(u => u.Correo == correo);

            return usuario != null ? MapUsuarioToUsuarioRespuesta(usuario) : null;
        }

        public async Task<bool> Registrar(UsuarioRegistrar usuario)
        {
            var nuevoUsuario = new Usuario
            {
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                Correo = usuario.Correo,
                Contrasena = usuario.Contrasena,
                TipoDocumentoId = usuario.TipoDocumentoId,
                NumeroDocumento = usuario.NumeroDocumento,
                GeneroId = usuario.GeneroId,
                Imagen = "imagen",
            };

            await _context.Usuario.AddAsync(nuevoUsuario);
            await _context.SaveChangesAsync();

            if (usuario.Imagen != null)
            {
                var url = await _imageRepository.SaveImageFromBase64Async(usuario.Imagen, $"usuario{nuevoUsuario.Id}");
                nuevoUsuario.Imagen = $"https://lazospetshop.azurewebsites.net/Image/{url.filename}";

                _context.Entry(nuevoUsuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<UsuarioRespuesta> Login(UsuarioLogin usuarioLogin)
        {
            var usuario = await _context.Usuario
                .Include(u => u.TipoDocumento)
                .Include(u => u.Genero)
                .FirstOrDefaultAsync(u => u.Correo == usuarioLogin.Correo && u.Contrasena == usuarioLogin.Contrasena);

            return usuario != null ? MapUsuarioToUsuarioRespuesta(usuario) : null;
        }

        private UsuarioRespuesta MapUsuarioToUsuarioRespuesta(Usuario usuario)
        {
            return new UsuarioRespuesta
            {
                Id = usuario.Id,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                Correo = usuario.Correo,
                Contrasena = usuario.Contrasena,
                TipoDocumento = usuario.TipoDocumentoId,
                NumeroDocumento = usuario.NumeroDocumento,
                Genero = usuario.GeneroId,
                Imagen = usuario.Imagen
            };
        }

        public async Task<bool> CambiarContrasena(UsuarioCambiarPass usuarioCambiarPass)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Correo == usuarioCambiarPass.Correo && u.Contrasena == usuarioCambiarPass.Contrasena);

            if (usuario == null)
            {
                return false;
            }

            usuario.Contrasena = usuarioCambiarPass.NuevaContrasena;
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
