using CRM_API.Services.Implementations;
using CRM_API.Services.Interfaces;
using DataAccess.Implementations;
using DataAccess.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context:
builder.Services.AddDbContext<CrmContext>();
builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConn")));

//Identity
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("CRM")
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 10;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

});

//Json Web Token
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });










//Unidad Trabajo:
builder.Services.AddScoped<IUnidadTrabajo, UnidadTrabajo>();

//DAL´S:
builder.Services.AddScoped<IClienteDAL, ClienteDAL>();
builder.Services.AddScoped<ITipoIdentificacionDAL, TipoIdentificacionDAL>();
builder.Services.AddScoped<IInfoEmpresaDAL, InfoEmpresaDALImpl>();
builder.Services.AddScoped<IEstadoMovimientoDAL, EstadoMovimientoDALImpl>();
builder.Services.AddScoped<ITipoEstadoPagoDAL, TipoEstadoPagoDALImpl>();
builder.Services.AddScoped<IServiciosDAL, ServiciosDALImpl>();
builder.Services.AddScoped<ISaldoDAL, SaldoDALImpl>();
builder.Services.AddScoped<ITipoMonedaDAL, TipoMonedaDALImpl>();
builder.Services.AddScoped<IMovimientoDAL, MovimientoDALImpl>();
builder.Services.AddScoped<ITipoMovimientoDAL, TipoMovimientoDALImpl>();


//Servicios:
builder.Services.AddScoped<IClienteSvc, ClienteSvc>();
builder.Services.AddScoped<ITipoIdentificacionSvc, TipoIdentificacionSvc>();
builder.Services.AddScoped<IInfoEmpresaServices, InfoEmpresaServices>();
builder.Services.AddScoped<IEstadoMovimientoServices, EstadoMovimientoServices>();
builder.Services.AddScoped<ITipoEstadoPagoServices, TipoEstadoPagoServices>();
builder.Services.AddScoped<IServiciosServicios, ServiciosServices>();
builder.Services.AddScoped<ISaldoServices, SaldoServices>();
builder.Services.AddScoped<ITipoMonedaServices, TipoMonedaServices>();
builder.Services.AddScoped<IMovimientoServices, MovimientoServices>();
builder.Services.AddScoped<ITipoMovimientoServices, TipoMovimientoServices>();

//IDENTITY
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ApikeyManager>();

app.UseAuthorization();

app.MapControllers();

app.Run();
