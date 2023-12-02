using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TServicio;
using Microsoft.AspNetCore.Mvc;

namespace API.Lazospetshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        [HttpGet("obtenertodos")]
        public async Task<ActionResult<IEnumerable<ServicioRespuesta>>> ObtenerTodos()
        {
            try
            {
                var servicios = await _servicioRepository.ObtenerTodos();
                return Ok(servicios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los servicios: {ex.Message}");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<ServicioRespuesta>> ObtenerPorId(int id)
        {
            try
            {
                var servicio = await _servicioRepository.ObtenerPorId(id);

                if (servicio != null)
                {
                    return Ok(servicio);
                }
                else
                {
                    return NotFound($"No se encontró el servicio con ID {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener el servicio: {ex.Message}");
            }
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<ServicioRespuesta>> RegistrarServicio(ServicioRegistrar servicio)
        {
            try
            {
                var nuevoServicio = await _servicioRepository.Registrar(servicio);
                return Ok(nuevoServicio);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al registrar el servicio: {ex.Message}");
            }
        }

        [HttpPut("actualizar")]
        public async Task<ActionResult<ServicioRespuesta>> ActualizarServicio(ServicioActualizar servicio)
        {
            try
            {
                var servicioActualizado = await _servicioRepository.Actualizar(servicio);

                if (servicioActualizado != null)
                {
                    return Ok(servicioActualizado);
                }
                else
                {
                    return NotFound($"No se encontró el servicio con ID {servicio.Id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el servicio: {ex.Message}");
            }
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<ServicioRespuesta>> EliminarServicio(int id)
        {
            try
            {
                var servicioEliminado = await _servicioRepository.Eliminar(id);

                if (servicioEliminado != null)
                {
                    return Ok(servicioEliminado);
                }
                else
                {
                    return NotFound($"No se encontró el servicio con ID {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el servicio: {ex.Message}");
            }
        }
    }
}
