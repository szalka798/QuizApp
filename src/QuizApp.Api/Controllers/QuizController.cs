using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Abstractions;
using QuizApp.Application.Commands;
using QuizApp.Application.Commands.Handlers;

namespace QuizApp.Api.Controllers;

[ApiController]
[Route("quizzes")]
public class QuizController : ControllerBase
{
    //private readonly ICheckUserAnswersService _checkUserAnswers;
    private readonly ICommandHandler<CheckUserAnswers>  _checkuseranswershandler;
    private readonly ICommandHandler<CreateQuiz> _createquizHandlerl;
    
    public QuizController(ICommandHandler<CheckUserAnswers> checkuseranswershandler, ICommandHandler<CreateQuiz> createquizHandlerl)
    {
        _createquizHandlerl = createquizHandlerl;
        _checkuseranswershandler = checkuseranswershandler;
    }


    
    [HttpPost("{quizId:guid}/useranswer")]
    public async Task<IActionResult> Post(Guid quizId, CheckUserAnswers command)
    {
        command.QuizId = quizId;
        await _checkuseranswershandler.HandleAsync(command);
        return NoContent();
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateQuiz command)
    {
        await _createquizHandlerl.HandleAsync(command);
        return NoContent();
    }
    
    
}