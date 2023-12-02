using API.Lazospetshop.Data;
using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TGenero;
using Microsoft.EntityFrameworkCore;

namespace API.Lazospetshop.Services
{
    public class GeneroService : IGeneroRepository
    {
        private readonly ApplicationContext _context;

        public GeneroService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genero>> ObtenerTodos()
        {
            return await _context.Genero.ToListAsync();
        }

        public async Task<Genero> ObtenerPorId(int id)
        {
            return await _context.Genero.FindAsync(id);
        }

        public async Task<Genero> Registrar(GeneroRegistrar genero)
        {
            var nuevoGenero = new Genero
            {
                Nombre = genero.Nombre
            };

            await _context.Genero.AddAsync(nuevoGenero);
            await _context.SaveChangesAsync();
            return nuevoGenero;
        }

        public async Task<Genero> Actualizar(Genero genero)
        {
            var generoEncontrado = await _context.Genero.FindAsync(genero.Id);
            if (generoEncontrado == null)
            {
                return null;
            }

            generoEncontrado.Nombre = genero.Nombre;
            await _context.SaveChangesAsync();
            return generoEncontrado;

        }

        public async Task<Genero> Eliminar(int id)
        {
            var generoEncontrado = await _context.Genero.FindAsync(id);
            if (generoEncontrado == null)
            {
                return null;
            }

            _context.Genero.Remove(generoEncontrado);
            await _context.SaveChangesAsync();
            return generoEncontrado;
        }
    }
}
