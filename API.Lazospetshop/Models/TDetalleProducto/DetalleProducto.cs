using API.Lazospetshop.Models.TCarrito;
using API.Lazospetshop.Models.TProducto;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Lazospetshop.Models.TDetalleProducto
{
    public class DetalleProducto
    {
        [Column(Order = 1)]
        public int CarritoId { get; set; }  
        [Column(Order = 2)]
        public int ProductoId { get; set; }

        public Carrito Carrito { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
        public float PrecioUnitario { get; set; }
        public float SubTotal { get; set; }
    }
}
