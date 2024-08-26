using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
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
