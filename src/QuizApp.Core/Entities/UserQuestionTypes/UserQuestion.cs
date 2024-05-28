using QuizApp.Core.ValueObjects;

namespace QuizApp.Core.Entities.UserQuestionTypes;

using QuestionTypes;

public abstract class UserQuestion
{
    public UserQuestionId Id { get; set; }
    public ScoredPoints ScoredPoints { get; set; }
    public IsCorrect IsCorrect { get; set; }
    public Question Question { get; set; }

    protected UserQuestion()
    {
    }
    
    protected UserQuestion(UserQuestionId id, ScoredPoints scoredPoints, IsCorrect isCorrect, Question question)
    {
        Id = id;
        ScoredPoints = scoredPoints;
        IsCorrect = isCorrect;
        Question = question;
    }
    
}