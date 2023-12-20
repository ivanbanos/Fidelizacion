using Aplicacion;
using Aplicacion.Authtentication;
using Authtentication;
using Datos;
using Datos.Extension;
using FidelizacionApi.Filtros;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Swagger Machine Utilization",
        Description = "Machine Utilization"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme { In = ParameterLocation.Header, Description = "JWT con Bearer", Name = "Authorization", Type = SecuritySchemeType.ApiKey });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }});

    c.CustomSchemaIds(x => x.FullName);

});
builder.Services.AddDbContext<FidelizacionContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConexionFidelizacion")));
builder.Services.AgregarRepositorios();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IAplicacionAnclas).Assembly));
builder.Services.AddAutoMapper(typeof(FidelizacionProfile));

builder.Services.AddSingleton<IConfigureOptions<SecretSettings>, ConfigureSecretSettings>();
builder.Services.AddSingleton<IAuthentication, JWTAuthentication>();
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
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();
