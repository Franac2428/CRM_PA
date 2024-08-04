using Entities.Entities;

namespace CRM.APIModels
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }

        public string? Nombre { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public string? Celular { get; set; }

        public int? IdTipoIdentificacion { get; set; }

        public string? Identificacion { get; set; }

        public bool? Eliminado { get; set; }

        public int? IdServicio { get; set; }

        public int? IdTipoPlan { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string? IdUsuarioCreacion { get; set; }

        public string? IdUsuarioModificacion { get; set; }

    }
}
