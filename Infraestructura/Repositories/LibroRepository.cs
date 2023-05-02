using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories;

public class LibroRepository : GenericRepository<Libro>, ILibroRepository
{
    public LibroRepository(TiendaContext tiendaContext) : base(tiendaContext)
    {
    }

    public override async Task<Libro> GetByIdAsync(int id)
    {
        
        return await _tiendaContext.Libros.Include(p => p.Cliente).FirstOrDefaultAsync(p => p.Id == id);

    }

    public override async Task<IEnumerable<Libro>> GetAllAsync()
    {
        return await _tiendaContext.Libros
                            .Include(u => u.Cliente)
                            .ToListAsync();
    }
}
