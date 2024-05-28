using QuizApp.Core.Exceptions;

namespace QuizApp.Core.ValueObjects;

public record SelectAnswerId
{
    public Guid Value { get; }

    public SelectAnswerId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }


    public static SelectAnswerId Create() => new SelectAnswerId(Guid.NewGuid());
    
    public static implicit operator Guid(SelectAnswerId date)
        => date.Value;
    
    public static implicit operator SelectAnswerId(Guid value)
        => new(value);
}