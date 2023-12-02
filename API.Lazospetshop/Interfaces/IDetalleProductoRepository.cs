using API.Lazospetshop.Models.TDetalleProducto;

namespace API.Lazospetshop.Interfaces
{
    public interface IDetalleProductoRepository
    {
        Task<IEnumerable<DetalleProductoRespuesta>> ObtenerTodos();
        Task<DetalleProductoRespuesta> ObtenerPorId(int carritoId, int productoId);
        Task<IEnumerable<DetalleProductoRespuesta>> ObtenerPorCarrito(int carritoId);
        Task<DetalleProductoRespuesta> Registrar(DetalleProductoRegistrar detalleProducto);
        Task<DetalleProductoRespuesta> Actualizar(DetalleProductoActualizar detalleProducto);
        Task<bool> Eliminar(int carritoId, int productoId);
    }
}
