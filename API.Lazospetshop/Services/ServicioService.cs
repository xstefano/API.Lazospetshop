using API.Lazospetshop.Data;
using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TServicio;
using Microsoft.EntityFrameworkCore;

namespace API.Lazospetshop.Services
{
    public class ServicioService : IServicioRepository
    {
        private readonly ApplicationContext _context;

        public ServicioService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServicioRespuesta>> ObtenerTodos()
        {
            var servicios = await _context.Servicio.ToListAsync();
            var serviciosRespuestas = servicios.Select(s => MapServicioToRespuesta(s)).ToList();
            return serviciosRespuestas;
        }

        public async Task<ServicioRespuesta> ObtenerPorId(int id)
        {
            var servicio = await _context.Servicio.FirstOrDefaultAsync(s => s.Id == id);
            return servicio != null ? MapServicioToRespuesta(servicio) : null;
        }

        public async Task<ServicioRespuesta> Registrar(ServicioRegistrar servicio)
        {
            var nuevoServicio = new Servicio
            {
                NombreServicio = servicio.NombreServicio,
                PrecioServicio = servicio.PrecioServicio,
                DescripcionServicio = servicio.DescripcionServicio
            };

            _context.Servicio.Add(nuevoServicio);
            await _context.SaveChangesAsync();

            return MapServicioToRespuesta(nuevoServicio);
        }

        public async Task<ServicioRespuesta> Actualizar(ServicioActualizar servicio)
        {
            var servicioExistente = await _context.Servicio.FirstOrDefaultAsync(s => s.Id == servicio.Id);

            if (servicioExistente != null)
            {
                servicioExistente.NombreServicio = servicio.NombreServicio;
                servicioExistente.PrecioServicio = servicio.PrecioServicio;
                servicioExistente.DescripcionServicio = servicio.DescripcionServicio;

                await _context.SaveChangesAsync();

                return MapServicioToRespuesta(servicioExistente);
            }

            return null;
        }

        public async Task<ServicioRespuesta> Eliminar(int id)
        {
            var servicioEliminado = await _context.Servicio.FirstOrDefaultAsync(s => s.Id == id);

            if (servicioEliminado != null)
            {
                _context.Servicio.Remove(servicioEliminado);
                await _context.SaveChangesAsync();

                return MapServicioToRespuesta(servicioEliminado);
            }

            return null;
        }

        private ServicioRespuesta MapServicioToRespuesta(Servicio servicio)
        {
            return new ServicioRespuesta
            {
                Id = servicio.Id,
                NombreServicio = servicio.NombreServicio,
                PrecioServicio = servicio.PrecioServicio,
                DescripcionServicio = servicio.DescripcionServicio
            };
        }
    }
}
