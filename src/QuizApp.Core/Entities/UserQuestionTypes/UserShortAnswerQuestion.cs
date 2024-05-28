using QuizApp.Core.ValueObjects;

namespace QuizApp.Core.Entities.UserQuestionTypes;
using QuestionTypes;

public class UserShortAnswerQuestion : UserQuestion
{
    
    public ShortAnswer ShortAnswer { get; set; }

    private UserShortAnswerQuestion()
    {
    }
    public UserShortAnswerQuestion(UserQuestionId userQuestionId, ScoredPoints scoredPoints, IsCorrect isCorrect, ShortAnswer shortAnswer, Question question) : base(userQuestionId, scoredPoints, isCorrect, question)
    {
        ShortAnswer = shortAnswer;
    }

    public static UserShortAnswerQuestion CreateUserAnswer(Question quizQuestion, ShortAnswer shortanswer)
    {
        var question = quizQuestion as ShortAnswerQuestion;
        if (question is null) throw new Exception();
        
        var isCorrect = shortanswer == question.CorrectAnswer;
        var points = isCorrect ? 1 : 0;

        return new UserShortAnswerQuestion(UserQuestionId.Create(), points, isCorrect, shortanswer,question);
    }


}