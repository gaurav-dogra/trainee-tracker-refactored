using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Trainee_Tracker.Domain.Interfaces;
using Trainee_Tracker.Models;

namespace Trainee_Tracker.Repository;
public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : class, IEntity
{
    private readonly ApplicationDbContext _context;

    protected RepositoryBase(ApplicationDbContext context)
    {
        _context = context;
    }
    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>()
            .AsNoTracking();
    }

    public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
    {
        return _context.Set<TEntity>()
            .Where(expression)
            .AsNoTracking();
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>()
            .Add(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>()
            .Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>()
            .Remove(entity);
    }
}
