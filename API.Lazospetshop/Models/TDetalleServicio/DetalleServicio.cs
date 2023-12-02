using API.Lazospetshop.Models.TCarrito;
using API.Lazospetshop.Models.TMascota;
using API.Lazospetshop.Models.TServicio;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Lazospetshop.Models.TDetalleServicio
{
    public class DetalleServicio
    {
        [Column(Order = 1)]
        public int CarritoId { get; set; }  
        [Column(Order = 2)]
        public int ServicioId { get; set; }

        public Carrito Carrito { get; set; }
        public Servicio Servicio { get; set; }

        public float PrecioUnitario { get; set; }
        public float SubTotal { get; set; }
        public int MascotaId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Mascota Mascota { get; set; }
    }
}
