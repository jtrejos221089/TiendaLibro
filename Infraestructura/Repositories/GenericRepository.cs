using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructura.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly TiendaContext _tiendaContext;

    public GenericRepository(TiendaContext tiendaContext)
    {
        _tiendaContext = tiendaContext;
    }

    public virtual void Add(T entity)
    {
        _tiendaContext.Set<T>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        _tiendaContext.Set<T>().AddRange(entities);
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _tiendaContext.Set<T>().Where(expression);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _tiendaContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _tiendaContext.Set<T>().FindAsync(id);
    }

    public virtual void Remove(T entity)
    {
        _tiendaContext.Set<T>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _tiendaContext.Set<T>().RemoveRange(entities);
    }

    public virtual void Update(T entity)
    {
        _tiendaContext.Set<T>().Update(entity);
    }
}
