using API.Lazospetshop.Models.TCategoria;

namespace API.Lazospetshop.Models.TProducto
{
    public class ProductoRegistrar
    {
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int CategoriaId { get; set; }
    }
}
