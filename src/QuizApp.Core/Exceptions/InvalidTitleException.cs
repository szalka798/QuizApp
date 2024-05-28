namespace QuizApp.Core.Exceptions;

public class InvalidTitleException : CustomException
{
    public string Title { get; set; }
    public InvalidTitleException(string title) : base($"Title {title} is invalid")
    {
        Title = title;
    }
}