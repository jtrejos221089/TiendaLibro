namespace Core.Interfaces;

public interface IUnitOfWork
{
    ILibroRepository Libros { get; }
    IClienteRepository Clientes { get; }
    Task <int> SaveAsync();
}
