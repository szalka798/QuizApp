namespace QuizApp.Core.ValueObjects;

public record IsCorrect
{
    public bool Value { get; }

    public IsCorrect(bool value)
    {
        Value = value;
    }
    
    public static implicit operator bool(IsCorrect isCorrect)
        => isCorrect.Value;

    public static implicit operator IsCorrect(bool value)
        => new(value);
    
}