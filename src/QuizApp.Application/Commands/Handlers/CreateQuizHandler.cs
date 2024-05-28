using QuizApp.Application.Abstractions;
using QuizApp.Application.Repository;
using QuizApp.Application.Utilities;
using QuizApp.Core.Entities;
using QuizApp.Core.ValueObjects;

namespace QuizApp.Application.Commands.Handlers;

public class CreateQuizHandler : ICommandHandler<CreateQuiz>
{
    
    private readonly IQuizRepository _quizRepository;

    public CreateQuizHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task HandleAsync(CreateQuiz command)
    {
        var questions = command.QuizQuestions.MapToListQuestion();

        throw new NotImplementedException();
    }
}