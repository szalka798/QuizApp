using QuizApp.Application.Abstractions;


namespace QuizApp.Application.Commands.Handlers;

public class CreateQuiz : ICommand
{
    public List<QuizQuestion> QuizQuestions { get; set; }
}

public abstract class QuizQuestion
{
    public string Title { get; set; }
}

public class QuizQuestionShortAnswer : QuizQuestion
{
    public string CorrectAnswer { get; set; }
}

public class QuizQuestionSingleChoiceAnswer : QuizQuestion
{
    public IEnumerable<QuestionSelectAnswer> SelectAnswers  { get; set; }
}

public class QuestionSelectAnswer
{
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
}

