using API.Lazospetshop.Models.TCategoria;

namespace API.Lazospetshop.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> ObtenerTodos();
        Task<Categoria> ObtenerPorId(int id);
        Task<Categoria> Registrar(CategoriaRegistrar categoria);
        Task<Categoria> Actualizar(Categoria categoria);
        Task<Categoria> Eliminar(int id);
    }
}
