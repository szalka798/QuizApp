using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Application.Abstractions;
using QuizApp.Application.Repository;
using QuizApp.Infrastructure.DAL.Repositories;


namespace QuizApp.Infrastructure.DAL;

internal static class Extensions
{
    static string constring = "Host=localhost;Username=postgres;Password=";
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<QuizAppDbContext>(x => x.UseNpgsql(constring));
        services.AddScoped<IQuizRepository, QuizRepository>();
        services.AddScoped<IUserQuizResultRepository, UserQuizResultRepository>();
        services.AddHostedService<DatabaseInitializer>();
        return services;
    }
}