using System.Collections;
using QuizApp.Application.Commands;
using QuizApp.Application.Commands.Handlers;
using QuizApp.Core.Entities.QuestionTypes;
using QuizApp.Core.Entities.UserQuestionTypes;
using QuizApp.Core.ValueObjects;

namespace QuizApp.Application.Utilities;

public static class MapUserQuestion
{
    

    public static UserQuestion MapToUserQuestion(this UserAnswer userAnswer, Question questions)
    {
        switch (userAnswer)
        {
            case ShortAnswerUserAnswer shortAnswerUserAnswer:
                return UserShortAnswerQuestion.CreateUserAnswer(questions, shortAnswerUserAnswer.ShortAnswer);
            case SingleChoiceUserAnswer singleChoiceUserAnswer:
                return UserSingleChoiceQuestion.CreateUserAnswer(questions, singleChoiceUserAnswer.SelectedAnswer);
            default:
                throw new Exception();
        }
    }
    
    public static IEnumerable<UserQuestion> MapToListUserQuestion(this IEnumerable<UserAnswer> userAnswers, IEnumerable<Question> questions)
    {
        var userQuestions = new List<UserQuestion>();
        foreach (var userAnswer in userAnswers)
        {
            var question = questions.FirstOrDefault(x => x.Id == new QuestionId(userAnswer.QuestionId));
            if (question is null)
            {
                throw new Exception();
            }
            var mapped = userAnswer.MapToUserQuestion(question);
            userQuestions.Add(mapped);
        }
        return userQuestions;
    }



    public static Question MapToQuestion(this QuizQuestion quizQuestion)
    {
        switch (quizQuestion)
        {
            case QuizQuestionShortAnswer shortAnswerQuestion:
                return new ShortAnswerQuestion(QuestionId.Create(), shortAnswerQuestion.Title, shortAnswerQuestion.CorrectAnswer);
            case QuizQuestionSingleChoiceAnswer quizQuestionSingleChoiceAnswer:
                return new SingleChoiceQuestion(QuestionId.Create(), quizQuestionSingleChoiceAnswer.Title, quizQuestionSingleChoiceAnswer.SelectAnswers.MapToListSelectAnswer());
            default:
                throw new Exception();
        }
    }

    public static IEnumerable<Question> MapToListQuestion(this IEnumerable<QuizQuestion> questionSelectAnswers)
    {
        var questions = new List<Question>();
        foreach (var questionSelectAnswer in questionSelectAnswers)
        {
            questions.Add(questionSelectAnswer.MapToQuestion());
        }

        return questions;
    }

    public static IEnumerable<SelectAnswer> MapToListSelectAnswer(this IEnumerable<QuestionSelectAnswer> questionSelectAnswers)
    {
        var selectAnswer = new List<SelectAnswer>();
        foreach (var questionSelectAnswer in questionSelectAnswers)
        {
            selectAnswer.Add(new SelectAnswer(SelectAnswerId.Create(), questionSelectAnswer.Content, questionSelectAnswer.IsCorrect));
        }

        return selectAnswer;
    }
    
    
}