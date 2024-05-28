using QuizApp.Core.Exceptions;

namespace QuizApp.Core.ValueObjects;

public record QuestionId
{
    public Guid Value { get; }

    public QuestionId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static QuestionId Create() => new QuestionId(Guid.NewGuid());
    
    public static implicit operator Guid(QuestionId date)
        => date.Value;
    
    public static implicit operator QuestionId(Guid value)
        => new(value);
    
}