namespace CRM.ViewModels
{
    public class MovimientosViewModel
    {
        public int IdMovimiento { get; set; }

        public int? IdTipoMovimiento { get; set; }
        public IEnumerable<TipoMovimientoViewModel> Movimiento { get; set; }

        public int? IdEstadoMovimiento { get; set; }
        public IEnumerable<TipoEstadoMovimientoViewModel> EstadoMovimiento { get; set; }

        public decimal? Monto { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string? IdUsuarioCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string? IdUsuarioModificacion { get; set; }

        public string? Comentario { get; set; }

        public byte[]? Imagen { get; set; }
    }
}
