using System.ComponentModel.DataAnnotations.Schema;

namespace API.Lazospetshop.Models.TServicio
{
    public class Servicio
    {
        [Column("idServicio")]
        public int Id { get; set; }
        public string NombreServicio { get; set; }
        public float PrecioServicio { get; set; }
        public string DescripcionServicio { get; set; }
    }
}
