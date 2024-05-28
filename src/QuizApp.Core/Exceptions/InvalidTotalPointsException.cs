namespace QuizApp.Core.Exceptions;

public class InvalidTotalPointsException : CustomException
{
    public int TotalPoints { get; set; }
    public InvalidTotalPointsException(int totalPoints) : base($"Total point {totalPoints} is invalid")
    {
        TotalPoints = totalPoints;
    }
    
}