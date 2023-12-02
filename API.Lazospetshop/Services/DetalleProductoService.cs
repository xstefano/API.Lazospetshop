using API.Lazospetshop.Data;
using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TDetalleProducto;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace API.Lazospetshop.Services
{
    public class DetalleProductoService : IDetalleProductoRepository
    {
        private readonly ApplicationContext _context;

        public DetalleProductoService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetalleProductoRespuesta>> ObtenerTodos()
        {
            var detalles = await _context.DetalleProducto
                .Select(dp => new DetalleProductoRespuesta
                {
                    CarritoId = dp.CarritoId,
                    ProductoId = dp.ProductoId,
                    Cantidad = dp.Cantidad,
                    PrecioUnitario = dp.PrecioUnitario,
                    SubTotal = dp.SubTotal
                })
                .ToListAsync();

            return detalles;
        }

        public async Task<DetalleProductoRespuesta> ObtenerPorId(int carritoId, int productoId)
        {
            var detalle = await _context.DetalleProducto
                .Where(dp => dp.CarritoId == carritoId && dp.ProductoId == productoId)
                .Select(dp => new DetalleProductoRespuesta
                {
                    CarritoId = dp.CarritoId,
                    ProductoId = dp.ProductoId,
                    Cantidad = dp.Cantidad,
                    PrecioUnitario = dp.PrecioUnitario,
                    SubTotal = dp.SubTotal
                })
                .FirstOrDefaultAsync();

            return detalle;
        }

        public async Task<IEnumerable<DetalleProductoRespuesta>> ObtenerPorCarrito(int carritoId)
        {
            var detalle = await _context.DetalleProducto
                .Where(dp => dp.CarritoId == carritoId)
                .Select(dp => new DetalleProductoRespuesta
                {
                    CarritoId = dp.CarritoId,
                    ProductoId = dp.ProductoId,
                    Cantidad = dp.Cantidad,
                    PrecioUnitario = dp.PrecioUnitario,
                    SubTotal = dp.SubTotal
                })
                .ToListAsync();

            return detalle;
        }

        public async Task<DetalleProductoRespuesta> Registrar(DetalleProductoRegistrar detalleProducto)
        {
            var nuevoDetalle = new DetalleProducto
            {
                CarritoId = detalleProducto.CarritoId,
                ProductoId = detalleProducto.ProductoId,
                Cantidad = detalleProducto.Cantidad,
                PrecioUnitario = detalleProducto.PrecioUnitario,
                SubTotal = detalleProducto.SubTotal
            };

            _context.DetalleProducto.Add(nuevoDetalle);
            await _context.SaveChangesAsync();

            return new DetalleProductoRespuesta
            {
                CarritoId = nuevoDetalle.CarritoId,
                ProductoId = nuevoDetalle.ProductoId,
                Cantidad = nuevoDetalle.Cantidad,
                PrecioUnitario = nuevoDetalle.PrecioUnitario,
                SubTotal = nuevoDetalle.SubTotal
            };
        }

        public async Task<DetalleProductoRespuesta> Actualizar(DetalleProductoActualizar detalleProducto)
        {
            var productoExistente = await _context.DetalleProducto
                .Where(dp => dp.CarritoId == detalleProducto.CarritoId && dp.ProductoId == detalleProducto.ProductoId)
                .FirstOrDefaultAsync();

            if (productoExistente == null)
            {
                return null;
            }

            productoExistente.Cantidad = detalleProducto.Cantidad;
            productoExistente.PrecioUnitario = detalleProducto.PrecioUnitario;
            productoExistente.SubTotal = detalleProducto.SubTotal;

            _context.Entry(productoExistente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new DetalleProductoRespuesta
            {
                CarritoId = productoExistente.CarritoId,
                ProductoId = productoExistente.ProductoId,
                Cantidad = productoExistente.Cantidad,
                PrecioUnitario = productoExistente.PrecioUnitario,
                SubTotal = productoExistente.SubTotal
            };
        }

        public async Task<bool> Eliminar(int carritoId, int productoId)
        {
            var productoExistente = await _context.DetalleProducto
                .Where(dp => dp.CarritoId == carritoId && dp.ProductoId == productoId)
                .FirstOrDefaultAsync();

            if (productoExistente == null)
            {
                return false;
            }

            _context.DetalleProducto.Remove(productoExistente);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
