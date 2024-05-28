using QuizApp.Core.Entities;
using QuizApp.Core.ValueObjects;

namespace QuizApp.Application.Repository;

public interface IQuizRepository
{
    Task<Quiz> GetAsync(QuizId quizId);
    Task AddAsync(Quiz quiz);
}