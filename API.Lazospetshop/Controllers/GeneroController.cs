using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TGenero;
using Microsoft.AspNetCore.Mvc;

namespace API.Lazospetshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        [HttpGet("obtenertodos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var generos = await _generoRepository.ObtenerTodos();
                return Ok(generos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener géneros: {ex.Message}");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var genero = await _generoRepository.ObtenerPorId(id);

                if (genero != null)
                {
                    return Ok(genero);
                }
                else
                {
                    return NotFound($"Género con ID {id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener género: {ex.Message}");
            }
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(GeneroRegistrar genero)
        {
            try
            {
                var nuevoGenero = await _generoRepository.Registrar(genero);
                return Ok(nuevoGenero);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear género: {ex.Message}");
            }
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> Actualizar(Genero genero)
        {
            try
            {
                var generoActualizado = await _generoRepository.Actualizar(genero);

                if (generoActualizado != null)
                {
                    return Ok(generoActualizado);
                }
                else
                {
                    return NotFound($"Género con ID {genero.Id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar género: {ex.Message}");
            }
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var generoEliminado = await _generoRepository.Eliminar(id);

                if (generoEliminado != null)
                {
                    return Ok(generoEliminado);
                }
                else
                {
                    return NotFound($"Género con ID {id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar género: {ex.Message}");
            }
        }
    }
}
