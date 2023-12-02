using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TProducto;
using Microsoft.AspNetCore.Mvc;

namespace API.Lazospetshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet("obtenertodos")]
        public async Task<ActionResult<IEnumerable<ProductoRespuesta>>> ObtenerTodos()
        {
            try
            {
                var productos = await _productoRepository.ObtenerTodos();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los productos: {ex.Message}");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<ProductoRespuesta>> ObtenerPorId(int id)
        {
            try
            {
                var producto = await _productoRepository.ObtenerPorId(id);

                if (producto != null)
                {
                    return Ok(producto);
                }
                else
                {
                    return NotFound($"No se encontró el producto con ID {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener el producto: {ex.Message}");
            }
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<ProductoRespuesta>> RegistrarProducto(ProductoRegistrar producto)
        {
            try
            {
                var nuevoProducto = await _productoRepository.Registrar(producto);
                return Ok(nuevoProducto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al registrar el producto: {ex.Message}");
            }
        }

        [HttpPut("actualizar")]
        public async Task<ActionResult<ProductoRespuesta>> ActualizarProducto(ProductoActualizar producto)
        {
            try
            {
                var productoActualizado = await _productoRepository.Actualizar(producto);

                if (productoActualizado != null)
                {
                    return Ok(productoActualizado);
                }
                else
                {
                    return NotFound($"No se encontró el producto con ID {producto.Id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el producto: {ex.Message}");
            }
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<ProductoRespuesta>> EliminarProducto(int id)
        {
            try
            {
                var productoEliminado = await _productoRepository.Eliminar(id);

                if (productoEliminado != null)
                {
                    return Ok(productoEliminado);
                }
                else
                {
                    return NotFound($"No se encontró el producto con ID {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el producto: {ex.Message}");
            }
        }
    }
}
