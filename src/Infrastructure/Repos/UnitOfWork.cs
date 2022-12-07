using Application.Abstractions;
using Application.Entities;

namespace Infrastructure.Repos;

public class UnitOfWork : IUnitOfWork
{
  private readonly AppDbContext _context;

  public UnitOfWork(AppDbContext context)
  {
    _context = context;
  }

  public Task Save() => _context.SaveChangesAsync();
}
