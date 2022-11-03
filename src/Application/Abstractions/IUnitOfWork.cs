using Application.Entities;

namespace Application.Abstractions;

public interface IUnitOfWork
{
  IRepository<Student> Students { get; }
  Task Save();
}