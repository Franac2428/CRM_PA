namespace CRM.APIModels
{
    public class GraficoModel
    {
        public GraficoMovimientos? Movimientos { get; set; }
        public List<GraficoPagosModel>? GraficoPagos { get; set; }
        public List<GraficoPagosModel>? GraficoPagosDolares { get; set; }


    }

    public class GraficoMovimientos
    {
        public decimal EntradasPendientes { get; set; }
        public decimal SalidasPendientes { get; set; }
        public decimal EntradasPagas { get; set; }
        public decimal SalidasPagas { get; set; }
    }
}
