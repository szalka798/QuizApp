using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Entities;
using QuizApp.Core.Entities.QuestionTypes;
using QuizApp.Core.Entities.UserQuestionTypes;

namespace QuizApp.Infrastructure.DAL;

public class QuizAppDbContext : DbContext
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<SelectAnswer> SelectAnswers { get; set; }

    public DbSet<UserQuizResult> UserQuizResults { get; set; }
    public DbSet<UserQuestion> UserQuestions { get; set; }
    

    public QuizAppDbContext(DbContextOptions<QuizAppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
    
}