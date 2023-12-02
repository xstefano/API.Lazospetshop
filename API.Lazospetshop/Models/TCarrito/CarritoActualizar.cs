namespace API.Lazospetshop.Models.TCarrito
{
    public class CarritoActualizar
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string MetodoPago { get; set; }
        public DateTime FechaPago { get; set; }
        public float MontoTotal { get; set; }
    }
}
