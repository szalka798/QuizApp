using JsonSubTypes;
using Newtonsoft.Json;
using QuizApp.Api.Enum;
using QuizApp.Application;
using QuizApp.Application.Commands;
using QuizApp.Application.Commands.Handlers;
using QuizApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(
        JsonSubtypesConverterBuilder.Of(typeof(UserAnswer), "QuestionType")
            .RegisterSubtype(typeof(ShortAnswerUserAnswer), AnswerTypeEnum.ShortAnswer)
            .RegisterSubtype(typeof(SingleChoiceUserAnswer), AnswerTypeEnum.SingleChoice)
            .SerializeDiscriminatorProperty()
            .Build()
        );
    options.SerializerSettings.Converters.Add(
        JsonSubtypesConverterBuilder.Of(typeof(QuizQuestion), "QuestionType")
            .RegisterSubtype(typeof(QuizQuestionShortAnswer), AnswerTypeEnum.ShortAnswer)
            .RegisterSubtype(typeof(QuizQuestionSingleChoiceAnswer), AnswerTypeEnum.SingleChoice)
            .SerializeDiscriminatorProperty()
            .Build()
    );
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();


