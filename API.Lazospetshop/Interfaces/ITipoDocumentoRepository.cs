using API.Lazospetshop.Models.TTipoDocumento;

namespace API.Lazospetshop.Interfaces
{
    public interface ITipoDocumentoRepository
    {
        Task<IEnumerable<TipoDocumento>> ObtenerTodos();
        Task<TipoDocumento> ObtenerPorId(int id);
        Task<TipoDocumento> Registrar(TipoDocumentoRegistrar tipoDocumento);
        Task<TipoDocumento> Actualizar(TipoDocumento tipoDocumento);
        Task<TipoDocumento> Eliminar(int id);
    }
}
