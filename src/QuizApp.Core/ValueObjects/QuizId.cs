using QuizApp.Core.Exceptions;

namespace QuizApp.Core.ValueObjects;

public record QuizId
{
    public Guid Value { get; }

    public QuizId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static QuizId Create() => new QuizId(Guid.NewGuid());
    
    public static implicit operator Guid(QuizId date)
        => date.Value;
    
    public static implicit operator QuizId(Guid value)
        => new(value);
    
}