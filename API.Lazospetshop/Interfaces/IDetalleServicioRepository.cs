using API.Lazospetshop.Models.TDetalleServicio;

namespace API.Lazospetshop.Interfaces
{
    public interface IDetalleServicioRepository
    {
        Task<IEnumerable<DetalleServicioRespuesta>> ObtenerTodos();
        Task<DetalleServicioRespuesta> ObtenerPorId(int carritoId, int servicioId);
        Task<IEnumerable<DetalleServicioRespuesta>> ObtenerPorCarrito(int carritoId);
        Task<DetalleServicioRespuesta> Registrar(DetalleServicioRegistrar detalleServicio);
        Task<DetalleServicioRespuesta> Actualizar(DetalleServicioActualizar detalleServicio);
        Task<bool> Eliminar(int carritoId, int servicioId);
    }
}
