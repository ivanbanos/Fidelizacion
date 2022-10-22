using Aplicacion.Command.Compania;
using Aplicacion.Query.Compania;
using Datos;
using Datos.Extension;
using MachineUtilizationApi;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FidelizacionContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConexionFidelizacion")));
builder.Services.AddMediatR(typeof(AgregarCompaniaCommand));
builder.Services.AddMediatR(typeof(ActualizarCompaniaCommand));
builder.Services.AddMediatR(typeof(EliminarCompaniaCommand));
builder.Services.AddMediatR(typeof(ObtenerCompaniaQuery));
builder.Services.AddMediatR(typeof(ObtenerCompaniasQuery));
builder.Services.AgregarRepositorios();

builder.Services.AddMvc(opt =>
{
    opt.Filters.Add(new ApiExceptionFilter());
});

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();
