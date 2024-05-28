namespace QuizApp.Core.Exceptions;

public sealed class InvalidContentException : CustomException
{
    public string Content { get; }

    public InvalidContentException(string content) : base($"Content {content} is invalid")
    {
        Content = content;
    }
}