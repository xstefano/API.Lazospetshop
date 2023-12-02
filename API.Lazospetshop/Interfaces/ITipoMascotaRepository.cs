using API.Lazospetshop.Models.TTipoMascota;

namespace API.Lazospetshop.Interfaces
{
    public interface ITipoMascotaRepository
    {
        Task<IEnumerable<TipoMascota>> ObtenerTodos();
        Task<TipoMascota> ObtenerPorId(int id);
        Task<TipoMascota> Registrar(TipoMascotaRegistrar tipoMascota);
        Task<TipoMascota> Actualizar(TipoMascota tipoMascota);
        Task<TipoMascota> Eliminar(int id);
    }
}
