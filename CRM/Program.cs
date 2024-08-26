using CRM.Helpers.Implementations;
using CRM.Helpers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(130); // Establecer el tiempo de expiración en minutos
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Agregar los scopes
builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IClienteHelper, ClienteHelper>();
builder.Services.AddScoped<IServiciosHelper, ServiciosHelper>();
builder.Services.AddScoped<IMovimientosHelper, MovimientoHelper>();
builder.Services.AddScoped<ILoginHelper, LoginHelper>();
builder.Services.AddScoped<IGraficosHelper, GraficosHelper>();
builder.Services.AddScoped<IPagosHelper, PagosHelper>();
builder.Services.AddScoped<IInfoEmpresaHelper, InfoEmpresaHelper>();
builder.Services.AddScoped<IRecibosHelper, RecibosHelper>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
