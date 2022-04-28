using System.Linq.Expressions;

namespace Trainee_Tracker.Domain.Interfaces;
public interface IRepositoryBase<T> where T : class, IEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
}
