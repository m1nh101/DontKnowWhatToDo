using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.Specifications;

public static class SpecificationEvaluator
{
  public static IEnumerable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> sources,
    ISpecification<TEntity> specification)
    where TEntity : class
  {
    IQueryable<TEntity> result = sources.AsNoTracking();

    if(specification.Criteria is not null)
      result = result.Where(specification.Criteria);

    _ = specification.Includes.Aggregate(result, (current, expression) =>
      current.Include(expression));

    if (specification.OrderBy is not null)
      result = result.OrderBy(specification.OrderBy);

    if (specification.OrderByDescending is not null)
      result = result.OrderByDescending(specification.OrderByDescending);

    return result.AsEnumerable();
  }
}