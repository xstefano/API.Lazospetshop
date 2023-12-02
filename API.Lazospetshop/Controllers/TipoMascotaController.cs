using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TTipoMascota;
using Microsoft.AspNetCore.Mvc;

namespace API.Lazospetshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMascotaController : ControllerBase
    {
        private readonly ITipoMascotaRepository _tipoMascotaRepository;

        public TipoMascotaController(ITipoMascotaRepository tipoMascotaRepository)
        {
            _tipoMascotaRepository = tipoMascotaRepository;
        }

        [HttpGet("obtenertodos")]
        public async Task<ActionResult<IEnumerable<TipoMascota>>> ObtenerTodos()
        {
            try
            {
                var tiposMascota = await _tipoMascotaRepository.ObtenerTodos();

                if (tiposMascota != null)
                {
                    return Ok(tiposMascota);
                }
                else
                {
                    return NotFound("No se encontraron tipos de mascota.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<TipoMascota>> ObtenerPorId(int id)
        {
            try
            {
                var tipoMascota = await _tipoMascotaRepository.ObtenerPorId(id);

                if (tipoMascota != null)
                {
                    return Ok(tipoMascota);
                }
                else
                {
                    return NotFound($"Tipo de mascota con ID {id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<TipoMascota>> Registrar(TipoMascotaRegistrar tipoMascota)
        {
            try
            {
                var resultado = await _tipoMascotaRepository.Registrar(tipoMascota);

                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest("Error al registrar el tipo de mascota.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("actualizar")]
        public async Task<ActionResult<TipoMascota>> Actualizar(TipoMascota tipoMascota)
        {
            try
            {
                var resultado = await _tipoMascotaRepository.Actualizar(tipoMascota);

                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return NotFound($"Tipo de mascota con ID {tipoMascota.Id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<TipoMascota>> Eliminar(int id)
        {
            try
            {
                var resultado = await _tipoMascotaRepository.Eliminar(id);

                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return NotFound($"Tipo de mascota con ID {id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
