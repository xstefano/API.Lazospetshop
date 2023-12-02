namespace API.Lazospetshop.Models.TDetalleServicio
{
    public class DetalleServicioRegistrar
    {
        public int CarritoId { get; set; }
        public int ServicioId { get; set; }
        public float PrecioUnitario { get; set; }
        public float SubTotal { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int MascotaId { get; set; }
    }
}
