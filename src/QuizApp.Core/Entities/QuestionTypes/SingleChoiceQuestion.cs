using QuizApp.Core.ValueObjects;

namespace QuizApp.Core.Entities.QuestionTypes;

public class SingleChoiceQuestion : Question
{

    public IEnumerable<SelectAnswer> SelectAnswers  { get; set; }

    private SingleChoiceQuestion()
    {
    }
    
    public SingleChoiceQuestion(QuestionId questionId, Title title, IEnumerable<SelectAnswer> selectAnswers) : base(questionId, title)
    {
        SelectAnswers = selectAnswers;
    }
}