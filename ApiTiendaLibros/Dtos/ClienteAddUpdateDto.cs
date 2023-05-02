namespace ApiTiendaLibros.Dtos
{
    public class ClienteAddUpdateDto
    {
        public int Id { get; set; }
        public int codigo_Cliente { get; set; }
        public string nombre_Cliente { get; set; }
        public int cedula_Cliente { get; set; }
        public DateTime fn_Cliente { get; set; }
    }
}
