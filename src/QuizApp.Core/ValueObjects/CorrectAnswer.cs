using QuizApp.Core.Exceptions;

namespace QuizApp.Core.ValueObjects;

public record CorrectAnswer
{
    public string Value { get; }

    public CorrectAnswer(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 100)
        {
            throw new InvalidCorrectAnswerException(value);
        }

        Value = value;
    }
    
    public static implicit operator string(CorrectAnswer correctAnswer)
        => correctAnswer.Value;

    public static implicit operator CorrectAnswer(string value)
        => new(value);
    
}