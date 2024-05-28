using QuizApp.Core.Exceptions;

namespace QuizApp.Core.ValueObjects;

public record Title
{
    public string Value { get; }

    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 400 or < 5)
        {
            throw new InvalidTitleException(value);
        }

        Value = value;
    }
    
    public static implicit operator string(Title title)
        => title.Value;

    public static implicit operator Title(string value)
        => new(value);
    
}