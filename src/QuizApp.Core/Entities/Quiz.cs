using QuizApp.Core.Entities.QuestionTypes;
using QuizApp.Core.ValueObjects;

namespace QuizApp.Core.Entities;

public class Quiz
{
    public QuizId Id { get; set; }
    public IEnumerable<Question> Questions { get; set; }
    
    private Quiz(){}
    public Quiz(QuizId id, IEnumerable<Question> questions)
    {
        if (questions.Count() < 1 )
        {
            throw new Exception();
        }
        
        Id = id;
        Questions = questions;
    }
}