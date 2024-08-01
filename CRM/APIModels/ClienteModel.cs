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

    }
}
