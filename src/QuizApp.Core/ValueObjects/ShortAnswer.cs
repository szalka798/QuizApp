using QuizApp.Core.Exceptions;

namespace QuizApp.Core.ValueObjects;

public record ShortAnswer
{
    public string Value { get; }

    public ShortAnswer(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 100)
        {
            throw new InvalidShortAnswerException(value);
        }

        Value = value;
    }
    
    public static implicit operator string(ShortAnswer shortAnswer)
        => shortAnswer.Value;

    public static implicit operator ShortAnswer(string value)
        => new(value);
    
}