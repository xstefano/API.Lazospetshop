using API.Lazospetshop.Models.TServicio;

namespace API.Lazospetshop.Interfaces
{
    public interface IServicioRepository
    {
        Task<IEnumerable<ServicioRespuesta>> ObtenerTodos();
        Task<ServicioRespuesta> ObtenerPorId(int id);
        Task<ServicioRespuesta> Registrar(ServicioRegistrar servicio);
        Task<ServicioRespuesta> Actualizar(ServicioActualizar servicio);
        Task<ServicioRespuesta> Eliminar(int id);
    }
}
