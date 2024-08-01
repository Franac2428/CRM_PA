namespace CRM_API.Services.Interfaces
{
    public interface IApikeyManager
    {
        Task InvokeAsync(HttpContext context); 
    }
}
