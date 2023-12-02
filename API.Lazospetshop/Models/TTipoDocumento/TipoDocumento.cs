using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Lazospetshop.Models.TTipoDocumento
{
    public class TipoDocumento
    {
        [Column("idTipoDocumento")]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
