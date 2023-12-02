using API.Lazospetshop.Models.TProducto;

namespace API.Lazospetshop.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<ProductoRespuesta>> ObtenerTodos();
        Task<ProductoRespuesta> ObtenerPorId(int id);
        Task<ProductoRespuesta> Registrar(ProductoRegistrar producto);
        Task<ProductoRespuesta> Actualizar(ProductoActualizar producto);
        Task<ProductoRespuesta> Eliminar(int id);
    }
}
