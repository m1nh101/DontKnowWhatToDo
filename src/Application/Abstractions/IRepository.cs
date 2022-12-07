namespace Application.Abstractions;

public interface IRepository<TEntity>
  where TEntity : class
{
  Task<IEnumerable<TEntity>> GetWithSpecification(ISpecification<TEntity> specification);
  Task<TEntity> FindWithSpecification(ISpecification<TEntity> specification);
  Task<TEntity?> Get(long id);
  Task<TEntity> Insert(TEntity entity);
  Task<TEntity> Update(TEntity entity);
  Task Remove(TEntity entity);
}