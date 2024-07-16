namespace CRM_API.Models
{
    public class SaldoModel
    {
        public int IdSaldo { get; set; }
        public int? IdCliente { get; set; }
        public decimal? MontoSaldo { get; set; }
        public int? IdMoneda { get; set; }
    }
}
