using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class GenericRepository<T> : IGeneric<T>
    where T : BaseEntity
{
    private readonly FarmaciaContext _context;

    public GenericRepository(FarmaciaContext context)
    {
        _context = context;
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(predicate);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task<T> GetByIdAsync(string id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> Entities)
    {
        _context.Set<T>().RemoveRange(Entities);
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}
