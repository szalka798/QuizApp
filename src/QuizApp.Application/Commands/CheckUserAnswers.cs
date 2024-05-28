
using System.Collections;
using QuizApp.Application.Abstractions;

namespace QuizApp.Application.Commands;

public class CheckUserAnswers : ICommand
{
    public Guid QuizId { get; set; }

    public IEnumerable<UserAnswer> Answers { get; set; }
}

public abstract class UserAnswer
{
    public Guid QuestionId { get; set; }
}

public class ShortAnswerUserAnswer : UserAnswer
{
    public string ShortAnswer { get; set; }
}

public class SingleChoiceUserAnswer : UserAnswer
{
    public Guid SelectedAnswer { get; set; }
}