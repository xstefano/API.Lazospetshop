using API.Lazospetshop.Models.TCarrito;

namespace API.Lazospetshop.Interfaces
{
    public interface ICarritoRepository
    {
        Task<IEnumerable<CarritoRespuesta>> ObtenerTodos();
        Task<CarritoRespuesta> ObtenerPorId(int id);
        Task<CarritoRespuesta> Registrar(CarritoRegistrar carrito);
        Task<CarritoRespuesta> Actualizar(CarritoActualizar carrito);
        Task<CarritoRespuesta> Eliminar(int id);
    }
}
