using Entities.Entities;

namespace CRM.APIModels
{
    public class ServiciosModel
    {
        public int IdServicio { get; set; }

        public string? Nombre { get; set; }

        public string? Monto { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string? IdUsuarioCreacion { get; set; }

        public string? IdUsuarioModificacion { get; set; }

		public int? IdMoneda { get; set; }

		public bool? Eliminado { get; set; }

	}
}
