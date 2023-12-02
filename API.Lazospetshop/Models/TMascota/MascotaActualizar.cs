using API.Lazospetshop.Models.TTipoMascota;
using API.Lazospetshop.Models.TUsuario;

namespace API.Lazospetshop.Models.TMascota
{
    public class MascotaActualizar
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Imagen { get; set; }
        public int TipoMascotaId { get; set; }
    }
}
