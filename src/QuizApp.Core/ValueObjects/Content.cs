using QuizApp.Core.Exceptions;

namespace QuizApp.Core.ValueObjects;

public record Content
{
    public string Value { get; }

    public Content(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 80)
        {
            throw new InvalidContentException(value);
        }

        Value = value;
    }
    
    public static implicit operator string(Content content)
        => content.Value;

    public static implicit operator Content(string value)
        => new(value);
    
}