using QuizApp.Core.ValueObjects;

namespace QuizApp.Core.Entities.QuestionTypes;

public abstract class Question
{
    public QuestionId Id { get; set; }
    public Title Title { get; set; }
    
    protected Question(){}
    
    public Question(QuestionId id, Title title)
    {
        Id = id;
        Title = title;
    }
}