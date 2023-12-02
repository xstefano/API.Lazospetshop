using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TDetalleProducto;
using Microsoft.AspNetCore.Mvc;
namespace API.Lazospetshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleProductoController : ControllerBase
    {
        private readonly IDetalleProductoRepository _detalleProductoRepository;

        public DetalleProductoController(IDetalleProductoRepository detalleProductoRepository)
        {
            _detalleProductoRepository = detalleProductoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleProductoRespuesta>>> ObtenerTodos()
        {
            try
            {
                var detalles = await _detalleProductoRepository.ObtenerTodos();
                return Ok(detalles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los detalles de productos: {ex.Message}");
            }
        }

        [HttpGet("id/{carritoId}/{productoId}")]
        public async Task<ActionResult<DetalleProductoRespuesta>> ObtenerPorId(int carritoId, int productoId)
        {
            try
            {
                var detalle = await _detalleProductoRepository.ObtenerPorId(carritoId, productoId);

                if (detalle != null)
                {
                    return Ok(detalle);
                }
                else
                {
                    return NotFound($"No se encontró el detalle de producto con Carrito ID {carritoId} y Producto ID {productoId}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener el detalle de producto: {ex.Message}");
            }
        }

        [HttpGet("id/{carritoId}")]
        public async Task<ActionResult<DetalleProductoRespuesta>> ObtenerPorCarrito(int carritoId)
        {
            try
            {
                var detalle = await _detalleProductoRepository.ObtenerPorCarrito(carritoId);

                if (detalle != null)
                {
                    return Ok(detalle);
                }
                else
                {
                    return NotFound($"No se encontró el detalle de producto con Carrito ID {carritoId}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener el detalle de producto: {ex.Message}");
            }
        }   

        [HttpPost("registrar")]
        public async Task<ActionResult<DetalleProductoRespuesta>> RegistrarDetalleProducto(DetalleProductoRegistrar detalleProducto)
        {
            try
            {
                var nuevoDetalle = await _detalleProductoRepository.Registrar(detalleProducto);
                return Ok(nuevoDetalle);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al registrar el detalle de producto: {ex.Message}");
            }
        }

        [HttpPut("actualizar")]
        public async Task<ActionResult<DetalleProductoRespuesta>> ActualizarDetalleProducto(DetalleProductoActualizar detalleProducto)
        {
            try
            {
                var detalleActualizado = await _detalleProductoRepository.Actualizar(detalleProducto);

                if (detalleActualizado != null)
                {
                    return Ok(detalleActualizado);
                }
                else
                {
                    return NotFound($"No se encontró el detalle de producto con Carrito ID {detalleProducto.CarritoId} y Producto ID {detalleProducto.ProductoId}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el detalle de producto: {ex.Message}");
            }
        }

        [HttpDelete("eliminar/{carritoId}/{productoId}")]
        public async Task<ActionResult<bool>> EliminarDetalleProducto(int carritoId, int productoId)
        {
            try
            {
                var resultado = await _detalleProductoRepository.Eliminar(carritoId, productoId);

                if (resultado)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound($"No se encontró el detalle de producto con Carrito ID {carritoId} y Producto ID {productoId}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el detalle de producto: {ex.Message}");
            }
        }
    }
}
