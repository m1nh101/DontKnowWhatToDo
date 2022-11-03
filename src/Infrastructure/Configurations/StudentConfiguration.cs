using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
  public void Configure(EntityTypeBuilder<Student> builder)
  {
    var students = new Student[]
    {
      new() { Id = 1, Age = 12, Name = "Student 1"},
      new() { Id = 2, Age = 13, Name = "Student 2"},
      new() { Id = 3, Age = 14, Name = "Student 3"},
      new() { Id = 4, Age = 21, Name = "Student 4"},
      new() { Id = 5, Age = 12, Name = "Student 5"},
      new() { Id = 6, Age = 23, Name = "Student 6"},
      new() { Id = 7, Age = 25, Name = "Student 7"},
      new() { Id = 8, Age = 29, Name = "Student 8"},
      new() { Id = 9, Age = 17, Name = "Student 9"},
      new() { Id = 10, Age = 18, Name = "Student 10"},
      new() { Id = 11, Age = 23, Name = "Student 11"},
      new() { Id = 12, Age = 24, Name = "Student 12"},
      new() { Id = 13, Age = 19, Name = "Student 13"},
      new() { Id = 14, Age = 20, Name = "Student 14"}
    };

    builder.HasKey(e => e.Id);

    builder.Property(e => e.Id).ValueGeneratedOnAdd();

    builder.HasData(students);
  }
}