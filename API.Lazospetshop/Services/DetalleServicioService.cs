using API.Lazospetshop.Data;
using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TDetalleServicio;
using Microsoft.EntityFrameworkCore;

namespace API.Lazospetshop.Services
{
    public class DetalleServicioService : IDetalleServicioRepository
    {
        private readonly ApplicationContext _context;

        public DetalleServicioService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DetalleServicioRespuesta>> ObtenerTodos()
        {
            var detalles = await _context.DetalleServicio.ToListAsync();
            return detalles.Select(MapDetalleServicioADetalleServicioRespuesta);
        }

        public async Task<DetalleServicioRespuesta> ObtenerPorId(int carritoId, int servicioId)
        {
            var detalle = await _context.DetalleServicio.FindAsync(carritoId, servicioId);
            return detalle != null ? MapDetalleServicioADetalleServicioRespuesta(detalle) : null;
        }

        public async Task<IEnumerable<DetalleServicioRespuesta>> ObtenerPorCarrito(int carritoId)
        {
            var detalle = await _context.DetalleServicio
                .Where(ds => ds.CarritoId == carritoId)
                .Select(ds => new DetalleServicioRespuesta
                {
                    CarritoId = ds.CarritoId,
                    ServicioId = ds.ServicioId,
                    PrecioUnitario = ds.PrecioUnitario,
                    SubTotal = ds.SubTotal,
                    FechaRegistro = ds.FechaRegistro,
                    MascotaId = ds.MascotaId
                })
                .ToListAsync();

            return detalle;
        }

        public async Task<DetalleServicioRespuesta> Registrar(DetalleServicioRegistrar detalleServicio)
        {
            var nuevoDetalle = new DetalleServicio
            {
                CarritoId = detalleServicio.CarritoId,
                ServicioId = detalleServicio.ServicioId,
                PrecioUnitario = detalleServicio.PrecioUnitario,
                SubTotal = detalleServicio.SubTotal,
                FechaRegistro = detalleServicio.FechaRegistro,
                MascotaId = detalleServicio.MascotaId
            };

            _context.DetalleServicio.Add(nuevoDetalle);
            await _context.SaveChangesAsync();
            return MapDetalleServicioADetalleServicioRespuesta(nuevoDetalle);
        }

        public async Task<DetalleServicioRespuesta> Actualizar(DetalleServicioActualizar detalleServicio)
        {
            var detalleExistente = await _context.DetalleServicio.FindAsync(detalleServicio.CarritoId, detalleServicio.ServicioId);

            if (detalleExistente == null)
            {
                return null;
            }

            detalleExistente.PrecioUnitario = detalleServicio.PrecioUnitario;
            detalleExistente.SubTotal = detalleServicio.SubTotal;
            detalleExistente.MascotaId = detalleServicio.MascotaId;

            _context.Entry(detalleExistente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return MapDetalleServicioADetalleServicioRespuesta(detalleExistente);
        }

        public async Task<bool> Eliminar(int carritoId, int servicioId)
        {
            var detalleExistente = await _context.DetalleServicio.FindAsync(carritoId, servicioId);

            if (detalleExistente == null)
            {
                return false;
            }

            _context.DetalleServicio.Remove(detalleExistente);
            await _context.SaveChangesAsync();

            return true;
        }

        private DetalleServicioRespuesta MapDetalleServicioADetalleServicioRespuesta(DetalleServicio detalle)
        {
            return new DetalleServicioRespuesta
            {
                CarritoId = detalle.CarritoId,
                ServicioId = detalle.ServicioId,
                PrecioUnitario = detalle.PrecioUnitario,
                SubTotal = detalle.SubTotal,
                FechaRegistro = detalle.FechaRegistro,
                MascotaId = detalle.MascotaId
            };
        }
    }
}
