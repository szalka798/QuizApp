namespace QuizApp.Core.Exceptions;

public class InvalidCorrectAnswerException : CustomException
{
    public string CorrectAnswer { get; set; }
    
    public InvalidCorrectAnswerException(string correctAnswer) : base($"CorrectAnswer {correctAnswer} is invalid")
    {
        CorrectAnswer = correctAnswer;
    }
}