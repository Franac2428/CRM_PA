namespace CRM_API.Models
{
    public class FiltrosReportes
    {
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string? IdUsuarioCreacion { get; set; }
        public DateTime? MesPago { get; set; }
        public string? NombreCliente { get; set; }
    }
}
