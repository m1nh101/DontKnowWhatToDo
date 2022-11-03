using Application.Abstractions;
using Application.Entities;

namespace Infrastructure.Repos;

public class UnitOfWork : IUnitOfWork
{
  private readonly AppDbContext _context;
  private readonly IRepository<Student> _students;

  public UnitOfWork(AppDbContext context)
  {
    _context = context;
    _students = new Repository<Student>(_context);
  }

  public IRepository<Student> Students => _students;

  public Task Save() => _context.SaveChangesAsync();
}
