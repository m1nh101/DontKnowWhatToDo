using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServicesConfiguration
{
  public static IServiceCollection ConfigureApplicationService(this IServiceCollection services)
  {
    var currentAssembly = typeof(ApplicationServicesConfiguration).Assembly;

    services.AddMediatR(currentAssembly);
    services.AddValidatorsFromAssembly(currentAssembly);

    return services;
  }
}