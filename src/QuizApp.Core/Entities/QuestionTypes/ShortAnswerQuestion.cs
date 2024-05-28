using QuizApp.Core.ValueObjects;

namespace QuizApp.Core.Entities.QuestionTypes;

public class ShortAnswerQuestion : Question
{
    public CorrectAnswer CorrectAnswer { get; set; }

    private ShortAnswerQuestion()
    {
    }
    
    public ShortAnswerQuestion(QuestionId questionId, Title title, CorrectAnswer correctAnswer) : base(questionId, title)
    {
        CorrectAnswer = correctAnswer;
    }
}