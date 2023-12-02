using API.Lazospetshop.Models.TGenero;
using API.Lazospetshop.Models.TTipoDocumento;

namespace API.Lazospetshop.Models.TUsuario
{
    public class UsuarioRespuesta
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        public int TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }

        public int Genero { get; set; }
        public string Imagen { get; set;}
    }
}
