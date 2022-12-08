using Application.Behaviors;
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

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateBehavior<,>));

    return services;
  }
}