using Application.Abstractions;
using Application.Entities;

namespace Infrastructure.Repos;

public class StudentRepository : Repository<Student>, IStudentRepositry
{
  public StudentRepository(AppDbContext context) : base(context)
  {
  }
}