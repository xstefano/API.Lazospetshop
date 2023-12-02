using System.ComponentModel.DataAnnotations.Schema;

namespace API.Lazospetshop.Models.TCategoria
{
    public class Categoria
    {
        [Column("idCategoria")]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
