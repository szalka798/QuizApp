using QuizApp.Core.ValueObjects;

namespace QuizApp.Core.Entities.UserQuestionTypes;
using QuestionTypes;

public class UserSingleChoiceQuestion : UserQuestion
{
    
    public SelectAnswerId SeletcedAnswerId { get; set; }

    private UserSingleChoiceQuestion()
    {
    }
    
    private UserSingleChoiceQuestion(UserQuestionId userQuestionId, ScoredPoints scoredPoints, IsCorrect isCorrect, SelectAnswerId seletcedAnswerId, Question question) : base(userQuestionId, scoredPoints, isCorrect, question)
    {
        SeletcedAnswerId = seletcedAnswerId;
    }

    public static UserSingleChoiceQuestion CreateUserAnswer(Question quizQuestion, SelectAnswerId selectedAnswer)
    {
        var question = quizQuestion as SingleChoiceQuestion;
        if (question is null) throw new Exception();

        var correctAnswer = question.SelectAnswers.SingleOrDefault(x => x.IsCorrect);

        if (correctAnswer is null) throw new Exception(); //brak poprawnychy odpowiedzi
        
        var isCorrect = selectedAnswer == correctAnswer.Id;
        var points = isCorrect ? 1 : 0;

        return new UserSingleChoiceQuestion(Guid.NewGuid(), points, isCorrect, selectedAnswer, quizQuestion);
    }



}