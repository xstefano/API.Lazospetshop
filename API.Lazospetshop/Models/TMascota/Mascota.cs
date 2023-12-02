using API.Lazospetshop.Models.TTipoMascota;
using API.Lazospetshop.Models.TUsuario;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Lazospetshop.Models.TMascota
{
    public class Mascota
    {
        [Column("idMascota")]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Imagen { get; set; }

        public int TipoMascotaId { get; set; }
        public TipoMascota TipoMascota { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
