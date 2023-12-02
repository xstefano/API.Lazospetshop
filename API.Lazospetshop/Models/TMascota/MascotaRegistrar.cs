namespace API.Lazospetshop.Models.TMascota
{
    public class MascotaRegistrar
    {
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Imagen { get; set; }
        public int TipoMascotaId { get; set; } 
        public int UsuarioId { get; set; }
    }
}
