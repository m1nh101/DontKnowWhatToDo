using Application.Abstractions;
using Application.Specifications;

namespace Infrastructure.Repos;

public class Repository<TEntity>
  : IRepository<TEntity>
  where TEntity : class
{
  protected readonly AppDbContext _context;

  public Repository(AppDbContext context)
  {
    _context = context;
  }

  public Task<IEnumerable<TEntity>> FindWithSpecification(ISpecification<TEntity> specification)
  {
    var result = SpecificationEvaluator.GetQuery(_context.Set<TEntity>(), specification);
    return Task.FromResult(result);
  }

  public virtual Task<TEntity?> Get(long id)
  {
    var entity = _context.Set<TEntity>().Find(id);
    return Task.FromResult(entity);
  }

  public virtual Task<TEntity> Insert(TEntity entity)
  {
    var record = _context.Set<TEntity>().Add(entity);
    return Task.FromResult(record.Entity);
  }

  public virtual Task Remove(TEntity entity)
  {
    _context.Set<TEntity>().Remove(entity);
    return Task.CompletedTask;
  }

  public virtual Task<TEntity> Update(TEntity entity)
  {
    var record = _context.Set<TEntity>().Update(entity);
    return Task.FromResult(record.Entity);
  }
}