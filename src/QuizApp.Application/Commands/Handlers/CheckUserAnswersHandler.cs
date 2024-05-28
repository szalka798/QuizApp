using QuizApp.Application.Abstractions;
using QuizApp.Application.Repository;
using QuizApp.Application.Utilities;
using QuizApp.Core.Entities;
using QuizApp.Core.Entities.UserQuestionTypes;

namespace QuizApp.Application.Commands.Handlers;

public class CheckUserAnswersHandler : ICommandHandler<CheckUserAnswers>
{
    
    private readonly IQuizRepository _quizRepository;
    private readonly IUserQuizResultRepository _userQuizResultRepository;

    public CheckUserAnswersHandler(IQuizRepository quizRepository, IUserQuizResultRepository userQuizResultRepository)
    {
        _quizRepository = quizRepository;
        _userQuizResultRepository = userQuizResultRepository;
    }
    
    public async Task HandleAsync(CheckUserAnswers command)
    {
        var quiz = await _quizRepository.GetAsync(command.QuizId);
        if (quiz is null)
        {
            //throw new QuizNotFoundException();
            throw new Exception();
        }
        
        var userQuestion= command.Answers.MapToListUserQuestion(quiz.Questions);
        var userQuizResult = UserQuizResult.CreateUserQuizResult(userQuestion, quiz);

        await _userQuizResultRepository.AddAsync(userQuizResult);
    }
}