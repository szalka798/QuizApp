using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Entities;
using QuizApp.Core.Entities.QuestionTypes;
using QuizApp.Core.ValueObjects;

namespace QuizApp.Infrastructure.DAL;

public class DatabaseInitializer : IHostedService
{
    
    private readonly IServiceProvider _serviceProvider;
    
    public DatabaseInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<QuizAppDbContext>();
        await dbContext.Database.MigrateAsync(cancellationToken);
        
        if (await dbContext.Quizzes.AnyAsync(cancellationToken))
        {
            return;
        }

        var quiz = new Quiz(QuizId.Create(), new List<Question>
        {
            new ShortAnswerQuestion(QuestionId.Create(), "The capital of Poland", "Warsaw"),
            new SingleChoiceQuestion(QuestionId.Create(), "2+2:", new List<SelectAnswer>()
            {
                new SelectAnswer(SelectAnswerId.Create(), "1", false),
                new SelectAnswer(SelectAnswerId.Create(), "2", false),
                new SelectAnswer(SelectAnswerId.Create(), "3", false),
                new SelectAnswer(SelectAnswerId.Create(), "4", true)
            })
        });
        
        await dbContext.Quizzes.AddAsync(quiz, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

    }
    
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
