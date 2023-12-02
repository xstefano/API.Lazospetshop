using API.Lazospetshop.Models.TMascota;

namespace API.Lazospetshop.Interfaces
{
    public interface IMascotaRepository
    {
        Task<IEnumerable<MascotaRespuesta>> ObtenerTodos();
        Task<MascotaRespuesta> ObtenerPorId(int id);
        Task<IEnumerable<MascotaRespuesta>> ObtenerMascotasPorUsuario(int id);
        Task<MascotaRespuesta> Registrar(MascotaRegistrar mascota);
        Task<MascotaRespuesta> Actualizar(MascotaActualizar mascota);
        Task<MascotaRespuesta> Eliminar(int id);
    }
}
