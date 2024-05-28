using QuizApp.Core.Exceptions;

namespace QuizApp.Core.ValueObjects;

public record TotalPoints
{
    public int Value { get; }

    public TotalPoints(int value)
    {
        if (value is < 0 )
        {
            throw new InvalidTotalPointsException(value);
        }
        
        Value = value;
    }
    
    public static implicit operator int(TotalPoints totalPoints)
        => totalPoints.Value;

    public static implicit operator TotalPoints(int value)
        => new(value);
}