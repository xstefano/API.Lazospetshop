using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TMascota;
using Microsoft.AspNetCore.Mvc;

namespace API.Lazospetshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly IMascotaRepository _mascotaRepository;

        public MascotaController(IMascotaRepository mascotaRepository)
        {
            _mascotaRepository = mascotaRepository;
        }

        [HttpGet("obtenertodos")]
        public async Task<ActionResult<IEnumerable<MascotaRespuesta>>> ObtenerTodos()
        {
            try
            {
                var mascotas = await _mascotaRepository.ObtenerTodos();
                return Ok(mascotas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener las mascotas: {ex.Message}");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<MascotaRespuesta>> ObtenerPorId(int id)
        {
            try
            {
                var mascota = await _mascotaRepository.ObtenerPorId(id);

                if (mascota == null)
                {
                    return NotFound($"No se encontró la mascota con ID {id}");
                }

                return Ok(mascota);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener la mascota: {ex.Message}");
            }
        }

        [HttpGet("mascotas/{id}")]
        public async Task<ActionResult<MascotaRespuesta>> ObtenerMascotasPorUsuario(int id)
        {
            try
            {
                var mascotas = await _mascotaRepository.ObtenerMascotasPorUsuario(id);

                if (mascotas == null)
                {
                    return NotFound($"No se encontraron mascotas para el usuario con ID {id}");
                }

                return Ok(mascotas);    
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener las mascotas: {ex.Message}");
            }
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(MascotaRegistrar mascota)
        {
            try
            {
                var resultado = await _mascotaRepository.Registrar(mascota);

                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest("Error al registrar la mascota.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("actualizar")]
        public async Task<ActionResult> Actualizar(MascotaActualizar mascota)
        {
            try
            {
                var resultado = await _mascotaRepository.Actualizar(mascota);

                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return NotFound($"Mascota con ID {mascota.Id} no encontrada.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                var resultado = await _mascotaRepository.Eliminar(id);

                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return NotFound($"Mascota con ID {id} no encontrada.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
