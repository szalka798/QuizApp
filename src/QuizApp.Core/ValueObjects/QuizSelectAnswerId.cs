using QuizApp.Core.Exceptions;

namespace QuizApp.Core.ValueObjects;

public record QuizSelectAnswerId
{
    public Guid Value { get; }

    public QuizSelectAnswerId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }
    
    public static implicit operator Guid(QuizSelectAnswerId date)
        => date.Value;
    
    public static implicit operator QuizSelectAnswerId(Guid value)
        => new(value);
    
}