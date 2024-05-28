namespace QuizApp.Core.Exceptions;

public class InvalidShortAnswerException : CustomException
{
    public string ShortAnswer { get;}
    public InvalidShortAnswerException(string shortAnswer) : base($"Short answer {shortAnswer} is invalid")
    {
        ShortAnswer = shortAnswer;
    }
}