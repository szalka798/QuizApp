using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Abstractions;
using QuizApp.Application.Repository;
using QuizApp.Core.Entities;
using QuizApp.Core.Entities.QuestionTypes;
using QuizApp.Core.Entities.UserQuestionTypes;
using QuizApp.Core.ValueObjects;

namespace QuizApp.Infrastructure.DAL.Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly QuizAppDbContext _dbContext;

    public QuizRepository(QuizAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Quiz> GetAsync(QuizId quizId)
        => await _dbContext.Quizzes
            .Include(x => x.Questions)
            .SingleOrDefaultAsync(x => x.Id == quizId);

    public async Task AddAsync(Quiz quiz)
    {
        await _dbContext.Quizzes.AddAsync(quiz);
        await _dbContext.SaveChangesAsync();
    }
}