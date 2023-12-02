using API.Lazospetshop.Models.TTipoMascota;
using API.Lazospetshop.Models.TUsuario;

namespace API.Lazospetshop.Models.TMascota
{
    public class MascotaRespuesta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Imagen { get; set; }
        public int TipoMascotaId { get; set; }
        public int UsuarioId { get; set; }
    }
}
