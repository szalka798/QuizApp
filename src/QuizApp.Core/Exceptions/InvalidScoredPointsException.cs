namespace QuizApp.Core.Exceptions;

public class InvalidScoredPointsException : CustomException
{
    public int ScoredPoints { get;}
    public InvalidScoredPointsException(int scoredPoints) : base($"ScoredPoints{scoredPoints} is invalid.")
    {
        ScoredPoints = scoredPoints;
    }
}