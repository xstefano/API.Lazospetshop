namespace API.Lazospetshop.Models.TUsuario
{
    public class UsuarioRegistrar
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        public int TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }

        public int GeneroId { get; set; }

        public string Imagen { get; set; }
    }
}
