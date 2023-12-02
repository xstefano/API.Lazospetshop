using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TCategoria;
using Microsoft.AspNetCore.Mvc;

namespace API.Lazospetshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet("obtenertodos")]
        public async Task<ActionResult<IEnumerable<Categoria>>> ObtenerTodos()
        {
            try
            {
                var categorias = await _categoriaRepository.ObtenerTodos();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener las categorías: {ex.Message}");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Categoria>> ObtenerPorId(int id)
        {
            try
            {
                var categoria = await _categoriaRepository.ObtenerPorId(id);

                if (categoria != null)
                {
                    return Ok(categoria);
                }
                else
                {
                    return NotFound($"No se encontró la categoría con ID {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener la categoría: {ex.Message}");
            }
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<Categoria>> RegistrarCategoria(CategoriaRegistrar categoria)
        {
            try
            {
                var nuevaCategoria = await _categoriaRepository.Registrar(categoria);
                return Ok(nuevaCategoria);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al registrar la categoría: {ex.Message}");
            }
        }

        [HttpPut("actualizar")]
        public async Task<ActionResult<Categoria>> ActualizarCategoria(Categoria categoria)
        {
            try
            {
                var categoriaActualizada = await _categoriaRepository.Actualizar(categoria);

                if (categoriaActualizada != null)
                {
                    return Ok(categoriaActualizada);
                }
                else
                {
                    return NotFound($"No se encontró la categoría con ID {categoria.Id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar la categoría: {ex.Message}");
            }
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<Categoria>> EliminarCategoria(int id)
        {
            try
            {
                var categoriaEliminada = await _categoriaRepository.Eliminar(id);

                if (categoriaEliminada != null)
                {
                    return Ok(categoriaEliminada);
                }
                else
                {
                    return NotFound($"No se encontró la categoría con ID {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar la categoría: {ex.Message}");
            }
        }
    }
}
