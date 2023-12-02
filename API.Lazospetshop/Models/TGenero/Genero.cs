using System.ComponentModel.DataAnnotations.Schema;

namespace API.Lazospetshop.Models.TGenero
{
    public class Genero
    {
        [Column("idGenero")]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
