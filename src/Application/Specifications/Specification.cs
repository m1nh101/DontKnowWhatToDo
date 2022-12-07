using System.Linq.Expressions;
using Application.Abstractions;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Specifications;

public class Specification<T> : ISpecification<T>
{
  protected Specification()
  {
    Includes = new();
  }

  protected Specification(Expression<Func<T, bool>> criteria)
  {
    Criteria = criteria;
    Includes = new();
  }

  public Expression<Func<T, bool>> Criteria { get; private set; } = default!;

  public Expression<Func<T, object>>? OrderBy { get; private set; }

  public Expression<Func<T, object>>? OrderByDescending { get; private set; }

  public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; }

  protected void AddInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> include) => Includes.Add(include);

  protected void AddOrderBy(Expression<Func<T, object>> orderBy) => OrderBy = orderBy;

  protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescending) => OrderByDescending = orderByDescending;
}