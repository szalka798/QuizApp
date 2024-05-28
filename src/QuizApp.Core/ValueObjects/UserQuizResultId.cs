using QuizApp.Core.Exceptions;

namespace QuizApp.Core.ValueObjects;

public record UserQuizResultId
{
    public Guid Value { get; }

    public UserQuizResultId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static UserQuizResultId Create() => new(Guid.NewGuid());
    
    public static implicit operator Guid(UserQuizResultId date)
        => date.Value;
    
    public static implicit operator UserQuizResultId(Guid value)
        => new(value);
    
}