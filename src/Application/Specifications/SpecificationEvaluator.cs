using Application.Abstractions;
using Application.Enums;
using Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Application.Specifications;

public static class SpecificationEvaluator
{
  public static Task<IEnumerable<TEntity>> GetQuery<TEntity>(IQueryable<TEntity> sources,
    ISpecification<TEntity> specification, Query state = Query.NoTracking)
    where TEntity : class
  {
    IQueryable<TEntity> result = state == Query.Tracking ? sources : sources.AsNoTracking();

    if(specification.Criteria is not null)
      result = result.Where(specification.Criteria);

    result = specification.Includes.Aggregate(result, (current, expression) =>
      expression(current));

    if (specification.OrderBy is not null)
      result = result.OrderBy(specification.OrderBy);

    if (specification.OrderByDescending is not null)
      result = result.OrderByDescending(specification.OrderByDescending);

    return Task.FromResult(result.AsEnumerable());
  }

  public static async Task<TEntity> Find<TEntity>(IQueryable<TEntity> sources, ISpecification<TEntity> specification)
    where TEntity : class
  {
    if (specification.Criteria is null)
      throw new MissingCriteriaException();

    var data = specification.Includes.Aggregate(sources, (current, expression) =>
      expression(current));

    var result = await data.FirstOrDefaultAsync(specification.Criteria);

    if (result == null)
      throw new NullReferenceException("entity not found");

    return result;
  }
}