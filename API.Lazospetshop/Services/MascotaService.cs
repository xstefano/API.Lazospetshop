using Microsoft.EntityFrameworkCore;
using API.Lazospetshop.Models.TMascota;
using API.Lazospetshop.Data;
using API.Lazospetshop.Interfaces;

public class MascotaService : IMascotaRepository
{
    private readonly ApplicationContext _context;
    private readonly IImageRepository _imageRepository;

    public MascotaService(ApplicationContext context, IImageRepository imageRepository)
    {
        _context = context;
        _imageRepository = imageRepository;
    }

    public async Task<IEnumerable<MascotaRespuesta>> ObtenerTodos()
    {
        var mascotas = await _context.Mascota
            .Include(m => m.TipoMascota)
            .ToListAsync();

        return mascotas.Select(m => MapMascotaEntityToMascotaRespuesta(m));
    }

    public async Task<MascotaRespuesta> ObtenerPorId(int id)
    {
        var mascotaEntity = await _context.Mascota
            .Include(m => m.TipoMascota)
            .FirstOrDefaultAsync(m => m.Id == id);

        return mascotaEntity != null ? MapMascotaEntityToMascotaRespuesta(mascotaEntity) : null;
    }

    public async Task<IEnumerable<MascotaRespuesta>> ObtenerMascotasPorUsuario(int id)
    {
        var mascotasUsuario = await _context.Mascota
            .Include(m => m.TipoMascota)
            .Where(m => m.UsuarioId == id)
            .ToListAsync();

        return mascotasUsuario.Select(m => MapMascotaEntityToMascotaRespuesta(m));
    }

    public async Task<MascotaRespuesta> Registrar(MascotaRegistrar mascota)
    {
        var nuevaMascota = new Mascota
        {
            Nombre = mascota.Nombre,
            Sexo = mascota.Sexo,
            Imagen = "imagen",
            TipoMascotaId = mascota.TipoMascotaId,
            UsuarioId = mascota.UsuarioId
        };

        await _context.Mascota.AddAsync(nuevaMascota);
        await _context.SaveChangesAsync();

        if (mascota.Imagen != null)
        {
            var url = await _imageRepository.SaveImageFromBase64Async(mascota.Imagen, $"mascota{nuevaMascota.Id}");
            nuevaMascota.Imagen = $"https://lazospetshop.azurewebsites.net/Image/{url.filename}";

            _context.Entry(nuevaMascota).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        return MapMascotaEntityToMascotaRespuesta(nuevaMascota);
    }

    public async Task<MascotaRespuesta> Actualizar(MascotaActualizar mascota)
    {
        var mascotaEntity = await _context.Mascota.FindAsync(mascota.Id);

        if (mascotaEntity == null)
        {
            return null;
        }

        mascotaEntity.Nombre = mascota.Nombre;
        mascotaEntity.Sexo = mascota.Sexo;
        mascotaEntity.Imagen = mascota.Imagen;
        mascotaEntity.TipoMascotaId = mascota.TipoMascotaId;

        _context.Update(mascotaEntity);
        await _context.SaveChangesAsync();
        return MapMascotaEntityToMascotaRespuesta(mascotaEntity);
    }

    public async Task<MascotaRespuesta> Eliminar(int id)
    {
        var mascotaEntity = await _context.Mascota.FindAsync(id);

        if (mascotaEntity == null)
        {
            return null;
        }

        _context.Mascota.Remove(mascotaEntity);
        await _context.SaveChangesAsync();
        return MapMascotaEntityToMascotaRespuesta(mascotaEntity);
    }

    private MascotaRespuesta MapMascotaEntityToMascotaRespuesta(Mascota mascotaEntity)
    {
        return new MascotaRespuesta
        {
            Id = mascotaEntity.Id,
            Nombre = mascotaEntity.Nombre,
            Sexo = mascotaEntity.Sexo,
            Imagen = mascotaEntity.Imagen,
            TipoMascotaId = mascotaEntity.TipoMascotaId,
            UsuarioId = mascotaEntity.UsuarioId
        };
    }
}
