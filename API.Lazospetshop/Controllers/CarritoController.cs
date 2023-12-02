using Microsoft.AspNetCore.Mvc;
using API.Lazospetshop.Models.TCarrito;
using API.Lazospetshop.Interfaces;

namespace API.Lazospetshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoRepository _carritoRepository;

        public CarritoController(ICarritoRepository carritoRepository)
        {
            _carritoRepository = carritoRepository;
        }

        [HttpGet("obtenertodos")]
        public async Task<ActionResult<IEnumerable<CarritoRespuesta>>> ObtenerTodos()
        {
            try
            {
                var carritos = await _carritoRepository.ObtenerTodos();
                return Ok(carritos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los carritos: {ex.Message}");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<CarritoRespuesta>> ObtenerPorId(int id)
        {
            try
            {
                var carrito = await _carritoRepository.ObtenerPorId(id);

                if (carrito != null)
                {
                    return Ok(carrito);
                }
                else
                {
                    return NotFound($"No se encontró el carrito con ID {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener el carrito: {ex.Message}");
            }
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<CarritoRespuesta>> RegistrarCarrito(CarritoRegistrar carrito)
        {
            try
            {
                var nuevoCarrito = await _carritoRepository.Registrar(carrito);
                return Ok(nuevoCarrito);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al registrar el carrito: {ex.Message}");
            }
        }

        [HttpPut("actualizar")]
        public async Task<ActionResult<CarritoRespuesta>> ActualizarCarrito(CarritoActualizar carrito)
        {
            try
            {
                var carritoActualizado = await _carritoRepository.Actualizar(carrito);

                if (carritoActualizado != null)
                {
                    return Ok(carritoActualizado);
                }
                else
                {
                    return NotFound($"No se encontró el carrito con ID {carrito.Id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el carrito: {ex.Message}");
            }
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<CarritoRespuesta>> EliminarCarrito(int id)
        {
            try
            {
                var carritoEliminado = await _carritoRepository.Eliminar(id);

                if (carritoEliminado != null)
                {
                    return Ok(carritoEliminado);
                }
                else
                {
                    return NotFound($"No se encontró el carrito con ID {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el carrito: {ex.Message}");
            }
        }
    }
}
