using API.Lazospetshop.Data;
using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TCarrito;
using Microsoft.EntityFrameworkCore;

namespace API.Lazospetshop.Services
{
    public class CarritoService : ICarritoRepository
    {
        private readonly ApplicationContext _context;

        public CarritoService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarritoRespuesta>> ObtenerTodos()
        {
            var carritos = await _context.Carrito.ToListAsync();
            return carritos.Select(c => MapToCarritoRespuesta(c));
        }

        public async Task<CarritoRespuesta> ObtenerPorId(int id)
        {
            var carrito = await _context.Carrito.FirstOrDefaultAsync(c => c.Id == id);

            return carrito != null ? MapToCarritoRespuesta(carrito) : null;
        }

        public async Task<CarritoRespuesta> Registrar(CarritoRegistrar carritoRegistrar)
        {
            var nuevoCarrito = new Carrito
            {
                IdUsuario = carritoRegistrar.IdUsuario,
                FechaCreacion = carritoRegistrar.FechaCreacion,
                MetodoPago = carritoRegistrar.MetodoPago,
                FechaPago = carritoRegistrar.FechaPago,
                MontoTotal = carritoRegistrar.MontoTotal
            };

            _context.Carrito.Add(nuevoCarrito);
            await _context.SaveChangesAsync();

            return MapToCarritoRespuesta(nuevoCarrito);
        }

        public async Task<CarritoRespuesta> Actualizar(CarritoActualizar carritoActualizar)
        {
            var carritoExistente = await _context.Carrito.FirstOrDefaultAsync(c => c.Id == carritoActualizar.Id);

            if (carritoExistente == null)
            {
                return null;
            }

            carritoExistente.IdUsuario = carritoActualizar.IdUsuario;
            carritoExistente.FechaCreacion = carritoActualizar.FechaCreacion;
            carritoExistente.MetodoPago = carritoActualizar.MetodoPago;
            carritoExistente.FechaPago = carritoActualizar.FechaPago;
            carritoExistente.MontoTotal = carritoActualizar.MontoTotal;

            _context.Entry(carritoExistente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return MapToCarritoRespuesta(carritoExistente);
        }

        public async Task<CarritoRespuesta> Eliminar(int id)
        {
            var carritoExistente = await _context.Carrito.FirstOrDefaultAsync(c => c.Id == id);

            if (carritoExistente == null)
            {
                return null;
            }

            _context.Carrito.Remove(carritoExistente);
            await _context.SaveChangesAsync();

            return MapToCarritoRespuesta(carritoExistente);
        }

        private CarritoRespuesta MapToCarritoRespuesta(Carrito carrito)
        {
            return new CarritoRespuesta
            {
                Id = carrito.Id,
                IdUsuario = carrito.IdUsuario,
                FechaCreacion = carrito.FechaCreacion,
                MetodoPago = carrito.MetodoPago,
                FechaPago = carrito.FechaPago,
                MontoTotal = carrito.MontoTotal
            };
        }
    }
}
