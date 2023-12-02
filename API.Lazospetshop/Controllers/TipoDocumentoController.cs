using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TTipoDocumento;
using Microsoft.AspNetCore.Mvc;

namespace API.Lazospetshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;

        public TipoDocumentoController(ITipoDocumentoRepository tipoDocumentoRepository)
        {
            _tipoDocumentoRepository = tipoDocumentoRepository;
        }

        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var tiposDocumentos = await _tipoDocumentoRepository.ObtenerTodos();
                return Ok(tiposDocumentos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener tipos de documentos: {ex.Message}");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var tipoDocumento = await _tipoDocumentoRepository.ObtenerPorId(id);

                if (tipoDocumento != null)
                {
                    return Ok(tipoDocumento);
                }
                else
                {
                    return NotFound($"Tipo de documento con ID {id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener tipo de documento: {ex.Message}");
            }
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(TipoDocumentoRegistrar tipoDocumento)
        {
            try
            {
                var nuevoTipoDocumento = await _tipoDocumentoRepository.Registrar(tipoDocumento);
                return Ok(nuevoTipoDocumento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear tipo de documento: {ex.Message}");
            }
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> Actualizar(TipoDocumento tipoDocumento)
        {
            try
            {
                var tipoDocumentoActualizado = await _tipoDocumentoRepository.Actualizar(tipoDocumento);

                if (tipoDocumentoActualizado != null)
                {
                    return Ok(tipoDocumentoActualizado);
                }
                else
                {
                    return NotFound($"Tipo de documento con ID {tipoDocumento.Id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar tipo de documento: {ex.Message}");
            }
        }

        [HttpDelete("eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var tipoDocumentoEliminado = await _tipoDocumentoRepository.Eliminar(id);

                if (tipoDocumentoEliminado != null)
                {
                    return Ok(tipoDocumentoEliminado);
                }
                else
                {
                    return NotFound($"Tipo de documento con ID {id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar tipo de documento: {ex.Message}");
            }
        }
    }
}
