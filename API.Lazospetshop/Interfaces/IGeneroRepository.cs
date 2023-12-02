using API.Lazospetshop.Models.TGenero;

namespace API.Lazospetshop.Interfaces
{
    public interface IGeneroRepository
    {
        Task<IEnumerable<Genero>> ObtenerTodos();
        Task<Genero> ObtenerPorId(int id);
        Task<Genero> Registrar(GeneroRegistrar genero);
        Task<Genero> Actualizar(Genero genero);
        Task<Genero> Eliminar(int id);
    }
}
