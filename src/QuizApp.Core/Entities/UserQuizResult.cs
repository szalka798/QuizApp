using QuizApp.Core.Entities;
using QuizApp.Core.Entities.UserQuestionTypes;
using QuizApp.Core.ValueObjects;

namespace QuizApp.Core.Entities;

public class UserQuizResult
{
    public UserQuizResultId Id { get; set; }
    public TotalPoints TotalPoints { get; set; }
    public IEnumerable<UserQuestion> UserQuestions { get; set; }
    public QuizId QuizId { get; set; }

    private UserQuizResult() {}
    public UserQuizResult(UserQuizResultId id, TotalPoints totalPoints, IEnumerable<UserQuestion> userQuestions, QuizId quizId)
    {
        Id = id;
        TotalPoints = totalPoints;
        UserQuestions = userQuestions;
        QuizId = quizId;

    }

    public static UserQuizResult CreateUserQuizResult(IEnumerable<UserQuestion> userQuestions, Quiz quiz)
    {
        int totalpoints = 0;
        foreach (var userQuestion in userQuestions)
        {
            if (quiz.Questions.All(x => x.Id != userQuestion.Question.Id)) throw new Exception();
            totalpoints += userQuestion.ScoredPoints;
        }
        
        return new UserQuizResult(UserQuizResultId.Create(), totalpoints ,userQuestions, quiz.Id);
    }
    
    
    
    
}