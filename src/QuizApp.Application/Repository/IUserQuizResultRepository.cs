using QuizApp.Core.Entities;

namespace QuizApp.Application.Repository;

public interface IUserQuizResultRepository
{
    Task AddAsync(UserQuizResult userQuizResult);
}