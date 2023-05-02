using Core.Interfaces;
using Infraestructura.Data;
using Infraestructura.Repositories;

namespace Infraestructura.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly TiendaContext _tiendaContext;
    private IClienteRepository _clienteReposity;
    private ILibroRepository _libroReposity;
    public UnitOfWork(TiendaContext tiendaContext)
    {
        _tiendaContext = tiendaContext;
    }

    public ILibroRepository Libros
    {
        get
        {
            if (_libroReposity == null)
            {
                _libroReposity = new LibroRepository(_tiendaContext);
            }
            return _libroReposity;
        }

    }

    public IClienteRepository Clientes
    {
        get
        {
            if (_clienteReposity == null)
            {
                _clienteReposity = new ClienteRepository(_tiendaContext);
            }
            return _clienteReposity;
        }
    }

    public async Task <int> SaveAsync()
    {
        return await _tiendaContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _tiendaContext.Dispose();
    }
}
