using API.Lazospetshop.Data;
using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TTipoDocumento;
using Microsoft.EntityFrameworkCore;

namespace API.Lazospetshop.Services
{
    public class TipoDocumentoService : ITipoDocumentoRepository
    {
        private readonly ApplicationContext _context;

        public TipoDocumentoService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoDocumento>> ObtenerTodos()
        {
            return await _context.TipoDocumento.ToListAsync();
        }

        public async Task<TipoDocumento> ObtenerPorId(int id)
        {
            return await _context.TipoDocumento.FindAsync(id);
        }

        public async Task<TipoDocumento> Registrar(TipoDocumentoRegistrar tipoDocumento)
        {
            var nuevoTipoDocumento = new TipoDocumento
            {
                Nombre = tipoDocumento.Nombre
            };

            await _context.TipoDocumento.AddAsync(nuevoTipoDocumento);
            await _context.SaveChangesAsync();
            return nuevoTipoDocumento;
        }

        public async Task<TipoDocumento> Actualizar(TipoDocumento tipoDocumento)
        {
            var tipoDocumentoEncontrado = await _context.TipoDocumento.FindAsync(tipoDocumento.Id);
            if (tipoDocumentoEncontrado == null)
            {
                return null;
            }

            tipoDocumentoEncontrado.Nombre = tipoDocumento.Nombre;
            await _context.SaveChangesAsync();
            return tipoDocumentoEncontrado;
        }

        public async Task<TipoDocumento> Eliminar(int id)
        {
            var tipoDocumentoEncontrado = await _context.TipoDocumento.FindAsync(id);

            if (tipoDocumentoEncontrado == null)
            {
                return null;
            }

            _context.TipoDocumento.Remove(tipoDocumentoEncontrado);
            await _context.SaveChangesAsync();
            return tipoDocumentoEncontrado;
        }
    }
}
