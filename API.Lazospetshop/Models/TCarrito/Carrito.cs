using API.Lazospetshop.Models.TUsuario;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Lazospetshop.Models.TCarrito
{
    public class Carrito
    {
        [Column("idCarrito")]
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string MetodoPago { get; set; }
        public DateTime FechaPago { get; set; } 
        public float MontoTotal { get; set; }
    }
}
