using CRM_API.Services.Interfaces;

namespace CRM_API.Services.Implementations
{
    public class ApikeyManager : IApikeyManager
    {

        private readonly RequestDelegate _requestDelegate;
        private const string APIKEYNAME = "Apikey";
        public ApikeyManager(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Apikey no disponible");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(APIKEYNAME);

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Apikey es incorrecto");
                return;

            }

            await _requestDelegate(context);

        }
    }
}
