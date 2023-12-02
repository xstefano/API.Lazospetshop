using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TProducto;
using API.Lazospetshop.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Lazospetshop.Services
{
    public class ProductoService : IProductoRepository
    {
        private readonly ApplicationContext _context;

        public ProductoService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductoRespuesta>> ObtenerTodos()
        {
            var productos = await _context.Producto.ToListAsync();
            return productos.Select(p => MapToProductoRespuesta(p)).ToList();
        }

        public async Task<ProductoRespuesta> ObtenerPorId(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            return producto != null ? MapToProductoRespuesta(producto) : null;
        }

        public async Task<ProductoRespuesta> Registrar(ProductoRegistrar producto)
        {
            var nuevoProducto = new Producto
            {
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Descripcion = producto.Descripcion,
                Imagen = producto.Imagen,
                CategoriaId = producto.CategoriaId
            };

            _context.Producto.Add(nuevoProducto);
            await _context.SaveChangesAsync();

            return MapToProductoRespuesta(nuevoProducto);
        }

        public async Task<ProductoRespuesta> Actualizar(ProductoActualizar producto)
        {
            var productoExistente = await _context.Producto.FindAsync(producto.Id);

            if (productoExistente != null)
            {
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Precio = producto.Precio;
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.Imagen = producto.Imagen;
                productoExistente.CategoriaId = producto.CategoriaId;

                _context.Entry(productoExistente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return MapToProductoRespuesta(productoExistente);
            }
            else
            {
                return null;
            }
        }

        public async Task<ProductoRespuesta> Eliminar(int id)
        {
            var producto = await _context.Producto.FindAsync(id);

            if (producto != null)
            {
                _context.Producto.Remove(producto);
                await _context.SaveChangesAsync();
                return MapToProductoRespuesta(producto);
            }
            else
            {
                return null;
            }
        }

        private ProductoRespuesta MapToProductoRespuesta(Producto producto)
        {
            return new ProductoRespuesta
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Descripcion = producto.Descripcion,
                Imagen = producto.Imagen,
                CategoriaId = producto.CategoriaId
            };
        }
    }
}
