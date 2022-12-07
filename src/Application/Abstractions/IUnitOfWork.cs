using Application.Entities;

namespace Application.Abstractions;

public interface IUnitOfWork
{
  Task Save();
}