namespace API.Lazospetshop.Models.TDetalleProducto
{
    public class DetalleProductoRegistrar
    {
        public int CarritoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnitario { get; set; }
        public float SubTotal { get; set; }
    }
}
