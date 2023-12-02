using API.Lazospetshop.Data;
using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TCategoria;
using Microsoft.EntityFrameworkCore;

namespace API.Lazospetshop.Services
{
    public class CategoriaService : ICategoriaRepository
    {
        private readonly ApplicationContext _context;

        public CategoriaService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> ObtenerTodos()
        {
            return await _context.Categoria.ToListAsync();
        }

        public async Task<Categoria> ObtenerPorId(int id)
        {
            return await _context.Categoria.FindAsync(id);
        }

        public async Task<Categoria> Registrar(CategoriaRegistrar categoriaRegistrar)
        {
            var nuevaCategoria = new Categoria
            {
                Nombre = categoriaRegistrar.Nombre
            };

            _context.Categoria.Add(nuevaCategoria);
            await _context.SaveChangesAsync();

            return nuevaCategoria;
        }

        public async Task<Categoria> Actualizar(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Eliminar(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return null;
            }

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }
    }
}
