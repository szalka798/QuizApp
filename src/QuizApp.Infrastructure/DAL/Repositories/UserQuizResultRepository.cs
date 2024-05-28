using QuizApp.Application.Repository;
using QuizApp.Core.Entities;

namespace QuizApp.Infrastructure.DAL.Repositories;

public class UserQuizResultRepository : IUserQuizResultRepository
{
    private readonly QuizAppDbContext _dbContext;

    public UserQuizResultRepository(QuizAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(UserQuizResult userQuizResult)
    {
        await _dbContext.UserQuizResults.AddAsync(userQuizResult);
        await _dbContext.SaveChangesAsync();
    }
}