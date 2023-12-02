using System.ComponentModel.DataAnnotations.Schema;
using API.Lazospetshop.Models.TCarrito;
using API.Lazospetshop.Models.TGenero;
using API.Lazospetshop.Models.TMascota;
using API.Lazospetshop.Models.TTipoDocumento;

namespace API.Lazospetshop.Models.TUsuario
{
    public class Usuario
    {
        [Column("idUsuario")]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        public int TipoDocumentoId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }

        public int GeneroId { get; set; }
        public Genero Genero { get; set; }

        public string? Imagen { get; set; }
        public List<Mascota> Mascotas { get; set; }
        public List<Carrito> Carritos { get; set; }
    }
}
