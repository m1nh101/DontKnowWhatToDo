using Application.Abstractions;
using Application.Specifications;
using Infrastructure;
using Infrastructure.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
  options.UseNpgsql("Host=localhost;Port=2345;Database=repo_practice;Username=postgres;Password=M1ng@2002",
    x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentRepositry, StudentRepository>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/api/students", (IUnitOfWork worker) =>
{
  return worker.Students.FindWithSpecification(new StudentGreaterThan20Specification(15));
});

//app.MapGet("/api/students", (IStudentRepositry students, IUnitOfWork worker) =>
//{
//  var result = students.Insert(new Application.Entities.Student { Name = "inserted students", Age = 15 });
//  worker.Save();
//  return result;
//});

app.Run();