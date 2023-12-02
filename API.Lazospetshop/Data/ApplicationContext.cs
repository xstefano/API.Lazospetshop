using API.Lazospetshop.Models.TDetalleProducto;
using API.Lazospetshop.Models.TCarrito;
using API.Lazospetshop.Models.TCategoria;
using API.Lazospetshop.Models.TDetalleServicio;
using API.Lazospetshop.Models.TGenero;
using API.Lazospetshop.Models.TMascota;
using API.Lazospetshop.Models.TProducto;
using API.Lazospetshop.Models.TServicio;
using API.Lazospetshop.Models.TTipoDocumento;
using API.Lazospetshop.Models.TTipoMascota;
using API.Lazospetshop.Models.TUsuario;
using Microsoft.EntityFrameworkCore;

namespace API.Lazospetshop.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Mascota> Mascota { get; set; }
        public DbSet<TipoMascota> TipoMascota { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<DetalleProducto> DetalleProducto { get; set; }
        public DbSet<DetalleServicio> DetalleServicio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleProducto>()
                .HasKey(dp => new { dp.CarritoId, dp.ProductoId });

            modelBuilder.Entity<DetalleServicio>()
                .HasKey(ds => new { ds.CarritoId, ds.ServicioId });

            modelBuilder.Entity<Mascota>()
               .HasOne(m => m.Usuario)
               .WithMany(u => u.Mascotas)
               .HasForeignKey(m => m.UsuarioId)
               .OnDelete(DeleteBehavior.NoAction)
               .Metadata
               .PrincipalToDependent
               .SetPropertyAccessMode(PropertyAccessMode.Field);

            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Carritos)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(modelBuilder);
        }
    }
}
