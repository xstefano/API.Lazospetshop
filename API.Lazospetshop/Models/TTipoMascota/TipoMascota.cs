using System.ComponentModel.DataAnnotations.Schema;

namespace API.Lazospetshop.Models.TTipoMascota
{
    public class TipoMascota
    {
        [Column("idTipoMascota")]
        public int Id { get; set; }
        public string Tipo { get; set; }
    }
}
