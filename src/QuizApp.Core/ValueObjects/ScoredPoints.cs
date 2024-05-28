using QuizApp.Core.Exceptions;

namespace QuizApp.Core.ValueObjects;

public record ScoredPoints
{
    public int Value { get; }

    public ScoredPoints(int value)
    {
        /*if (value is < 0 )
        {
            throw new InvalidScoredPointsException(value);
        }*/
        
        Value = value;
    }
    
    public static implicit operator int(ScoredPoints scoredPoints)
        => scoredPoints.Value;

    public static implicit operator ScoredPoints(int value)
        => new(value);
}