using Microsoft.Extensions.DependencyInjection;
using QuizApp.Application.Abstractions;
using QuizApp.Application.Commands;
using QuizApp.Application.Commands.Handlers;

namespace QuizApp.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ICommandHandler<>).Assembly;

        services.Scan(s => s.FromAssemblies(applicationAssembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        //services.AddScoped<ICheckUserAnswersService, CheckUserAnswersService>();
        
        return services;
    }
}