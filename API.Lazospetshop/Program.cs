using API.Lazospetshop.Data;
using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddScoped<IUsuarioRepository, UsuarioService>();
builder.Services.AddScoped<IGeneroRepository, GeneroService>();
builder.Services.AddScoped<ITipoDocumentoRepository, TipoDocumentoService>();
builder.Services.AddScoped<IMascotaRepository, MascotaService>();
builder.Services.AddScoped<IServicioRepository, ServicioService>();
builder.Services.AddScoped<ICarritoRepository, CarritoService>();
builder.Services.AddScoped<IDetalleServicioRepository, DetalleServicioService>();
builder.Services.AddScoped<IDetalleProductoRepository, DetalleProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoService>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaService>();
builder.Services.AddScoped<ITipoMascotaRepository, TipoMascotaService>();
builder.Services.AddScoped<IImageRepository, ImageService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
