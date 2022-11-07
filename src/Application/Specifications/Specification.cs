using System.Linq.Expressions;
using Application.Abstractions;

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

  public List<Expression<Func<T, object>>> Includes { get; }

  public Expression<Func<T, object>>? OrderBy { get; private set; }

  public Expression<Func<T, object>>? OrderByDescending { get; private set; }

  protected void AddInclude(Expression<Func<T, object>> include) => Includes.Add(include);

  protected void AddOrderBy(Expression<Func<T, object>> orderBy) => OrderBy = orderBy;

  protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescending) => OrderByDescending = orderByDescending;
}