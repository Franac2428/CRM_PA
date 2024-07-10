using CRM_API.Services.Implementations;
using CRM_API.Services.Interfaces;
using DataAccess.Implementations;
using DataAccess.Interfaces;
using Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context:
builder.Services.AddDbContext<CrmContext>();

//Unidad Trabajo:
builder.Services.AddScoped<IUnidadTrabajo, UnidadTrabajo>();

//DAL´S:
builder.Services.AddScoped<IClienteDAL, ClienteDAL>();
builder.Services.AddScoped<ITipoIdentificacionDAL, TipoIdentificacionDAL>();

//Servicios:
builder.Services.AddScoped<IClienteSvc, ClienteSvc>();
builder.Services.AddScoped<ITipoIdentificacionSvc, TipoIdentificacionSvc>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
