using QuizApp.Core.Exceptions;

namespace QuizApp.Core.ValueObjects;

public record UserQuestionId
{
    public Guid Value { get; }

    public UserQuestionId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static UserQuestionId Create() => new UserQuestionId(Guid.NewGuid());
    
    public static implicit operator Guid(UserQuestionId date)
        => date.Value;
    
    public static implicit operator UserQuestionId(Guid value)
        => new(value);
    
}