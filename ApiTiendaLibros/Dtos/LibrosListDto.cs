using Core.Entities;

namespace ApiTiendaLibros.Dtos;

public class LibrosListDto
{
    public int Id { get; set; }
    public int codigo_Libro { get; set; }
    public string nombre_Libro { get; set; }
    public string nombre_Empresa { get; set; }
    public string descripcion_Libro { get; set; }
    public bool estado_Libro { get; set; }
    public decimal precio_Libro { get; set; }
    public int codigo_Cliente { get; set; }
    public DateTime fechaIngreso_Libro { get; set; }
    public DateTime? fechaRetiro_Libro { get; set; }
    public int? ClienteId { get; set; }
    public string Cliente { get; set; }
}
