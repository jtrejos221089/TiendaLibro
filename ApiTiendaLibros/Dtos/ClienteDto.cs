using Core.Entities;

namespace ApiTiendaLibros.Dtos
{
    public class ClienteDto
    {
        public string Id { get; set; }
        public string codigo_Cliente { get; set; }
        public string nombre_Cliente { get; set; }
        public string cedula_Cliente { get; set; }
        public DateTime fn_Cliente { get; set; }
    }
}
