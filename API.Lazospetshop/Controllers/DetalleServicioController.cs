using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TDetalleServicio;
using Microsoft.AspNetCore.Mvc;

namespace API.Lazospetshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleServicioController : ControllerBase
    {
        private readonly IDetalleServicioRepository _detalleServicioRepository;

        public DetalleServicioController(IDetalleServicioRepository detalleServicioRepository)
        {
            _detalleServicioRepository = detalleServicioRepository;
        }

        [HttpGet("obtenertodos")]
        public async Task<ActionResult<IEnumerable<DetalleServicioRespuesta>>> ObtenerTodos()
        {
            try
            {
                var detalles = await _detalleServicioRepository.ObtenerTodos();
                return Ok(detalles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los detalles de servicio: {ex.Message}");
            }
        }

        [HttpGet("id/{carritoId}/{servicioId}")]
        public async Task<ActionResult<DetalleServicioRespuesta>> ObtenerPorId(int carritoId, int servicioId)
        {
            try
            {
                var detalle = await _detalleServicioRepository.ObtenerPorId(carritoId, servicioId);

                if (detalle != null)
                {
                    return Ok(detalle);
                }
                else
                {
                    return NotFound($"No se encontró el detalle de servicio con CarritoId {carritoId} y ServicioId {servicioId}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener el detalle de servicio: {ex.Message}");
            }
        }

        [HttpGet("id/{carritoId}")]
        public async Task<ActionResult<DetalleServicioRespuesta>> ObtenerPorCarrito(int carritoId)
        {
            try
            {
                var detalle = await _detalleServicioRepository.ObtenerPorCarrito(carritoId);

                if (detalle != null)
                {
                    return Ok(detalle);
                }
                else
                {
                    return NotFound($"No se encontró el detalle de servicio con CarritoId {carritoId}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener el detalle de servicio: {ex.Message}");
            }
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<DetalleServicioRespuesta>> RegistrarDetalleServicio(DetalleServicioRegistrar detalleServicio)
        {
            try
            {
                var nuevoDetalle = await _detalleServicioRepository.Registrar(detalleServicio);
                return Ok(nuevoDetalle);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al registrar el detalle de servicio: {ex.Message}");
            }
        }

        [HttpPut("actualizar")]
        public async Task<ActionResult<DetalleServicioRespuesta>> ActualizarDetalleServicio([FromBody] DetalleServicioActualizar detalleServicio)
        {
            try
            {
                var detalleActualizado = await _detalleServicioRepository.Actualizar(detalleServicio);

                if (detalleActualizado != null)
                {
                    return Ok(detalleActualizado);
                }
                else
                {
                    return NotFound($"No se encontró el detalle de servicio con CarritoId {detalleServicio.CarritoId} y ServicioId {detalleServicio.ServicioId}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el detalle de servicio: {ex.Message}");
            }
        }

        [HttpDelete("eliminar/{carritoId}/{servicioId}")]
        public async Task<ActionResult<bool>> EliminarDetalleServicio(int carritoId, int servicioId)
        {
            try
            {
                var eliminado = await _detalleServicioRepository.Eliminar(carritoId, servicioId);

                if (eliminado)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound($"No se encontró el detalle de servicio con CarritoId {carritoId} y ServicioId {servicioId}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el detalle de servicio: {ex.Message}");
            }
        }
    }
}
