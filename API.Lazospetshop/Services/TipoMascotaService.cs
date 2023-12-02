using Microsoft.EntityFrameworkCore;
using API.Lazospetshop.Models.TTipoMascota;
using API.Lazospetshop.Data;
using API.Lazospetshop.Interfaces;

namespace API.Lazospetshop.Services
{
    public class TipoMascotaService : ITipoMascotaRepository
    {
        private readonly ApplicationContext _context;

        public TipoMascotaService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoMascota>> ObtenerTodos()
        {
            return await _context.TipoMascota.ToListAsync();
        }

        public async Task<TipoMascota> ObtenerPorId(int id)
        {
            return await _context.TipoMascota.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TipoMascota> Registrar(TipoMascotaRegistrar tipoMascota)
        {
            var nuevoTipoMascota = new TipoMascota
            {
                Tipo = tipoMascota.Tipo
            };

            await _context.TipoMascota.AddAsync(nuevoTipoMascota);
            await _context.SaveChangesAsync();

            return nuevoTipoMascota;
        }

        public async Task<TipoMascota> Actualizar(TipoMascota tipoMascota)
        {
            var tipoMascotaEntity = await _context.TipoMascota.FindAsync(tipoMascota.Id);

            if (tipoMascotaEntity == null)
            {
                return null;
            }

            tipoMascotaEntity.Tipo = tipoMascota.Tipo;

            _context.Update(tipoMascotaEntity);
            await _context.SaveChangesAsync();
            return tipoMascotaEntity;
        }

        public async Task<TipoMascota> Eliminar(int id)
        {
            var tipoMascotaEntity = await _context.TipoMascota.FindAsync(id);

            if (tipoMascotaEntity == null)
            {
                return null;
            }

            _context.TipoMascota.Remove(tipoMascotaEntity);
            await _context.SaveChangesAsync();
            return tipoMascotaEntity;
        }
    }
}
