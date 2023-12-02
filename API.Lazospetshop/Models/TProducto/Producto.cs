using API.Lazospetshop.Models.TCategoria;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Lazospetshop.Models.TProducto
{
    public class Producto
    {
        [Column("idProducto")]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
