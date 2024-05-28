using QuizApp.Core.ValueObjects;

namespace QuizApp.Core.Entities.QuestionTypes;

public class SelectAnswer
{
    public SelectAnswerId Id { get; set; }
    public Content Content { get; set; }
    public IsCorrect IsCorrect { get; set; }

    public SelectAnswer(SelectAnswerId id, Content content, IsCorrect isCorrect)
    {
        Id = id;
        Content = content;
        IsCorrect = isCorrect;
    }
}