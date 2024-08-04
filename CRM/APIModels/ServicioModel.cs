using Entities.Entities;

namespace CRM.APIModels
{
    public class ServicioModel
    {
        public int IdServicio { get; set; }

        public string? Nombre { get; set; }

        public string? Monto { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string? IdUsuarioCreacion { get; set; }

        public string? IdUsuarioModificacion { get; set; }

		public string? IdMoneda { get; set; }

		public string? Eliminado { get; set; }

	}
}
