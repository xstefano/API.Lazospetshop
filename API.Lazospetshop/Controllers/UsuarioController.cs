using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TUsuario;
using Microsoft.AspNetCore.Mvc;

namespace API.Lazospetshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("obtenertodos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var usuarios = await _usuarioRepository.ObtenerTodos();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener usuarios: {ex.Message}");
            }
        }

        [HttpGet("ObtenerPorId/{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.ObtenerPorId(id);

                if (usuario != null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return NotFound($"Usuario con ID {id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener usuario: {ex.Message}");
            }
        }

        [HttpGet("ObtenerPorCorreo/{correo}")]
        public async Task<IActionResult> ObtenerPorCorreo(string correo)
        {
            try
            {
                var usuario = await _usuarioRepository.ObtenerPorCorreo(correo);

                if (usuario != null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return NotFound($"Usuario con correo {correo} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener usuario: {ex.Message}");
            }
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioRegistrar usuario)
        {
            await _usuarioRepository.Registrar(usuario);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            try
            {
                var usuario = await _usuarioRepository.Login(usuarioLogin);

                if (usuario != null)
                {
                    return Ok(new[] { usuario });
                }
                else
                {
                    return BadRequest("Credenciales inválidas");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al realizar el inicio de sesión: {ex.Message}");
            }
        }

        [HttpPut("cambiarcontrasena")]
        public async Task<IActionResult> CambiarContrasena(UsuarioCambiarPass usuarioCambiarPass)
        {
            try
            {
                var usuario = await _usuarioRepository.CambiarContrasena(usuarioCambiarPass);

                if (usuario != null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return BadRequest("Credenciales inválidas");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al realizar el cambio de contraseña: {ex.Message}");
            }
        }
    }
}
