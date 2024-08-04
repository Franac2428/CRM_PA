namespace CRM.APIModels
{
    public class CRMResponse
    {
        public string? Mensaje { get; set; }
        public int Codigo { get; set; }
        public object? Data { get; set; }
        public string Status { get; set; }
    }

    public class CRMResponse<TEntity> : CRMResponse
    {
        public List<TEntity> Listado { get; set; }
        public TEntity Entidad { get; set; }

        public CRMResponse()
        {
            Listado = new List<TEntity>();
        }
    }


}
