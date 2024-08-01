namespace CRM.Helpers.Interfaces
{
    public interface IServiceRepository
    {
        HttpResponseMessage GetResponse(string url);
        HttpResponseMessage PutResponse(string url, object model);
        HttpResponseMessage PostResponse(string url, object model);
        HttpResponseMessage DeleteResponse(string url);
    }
}
