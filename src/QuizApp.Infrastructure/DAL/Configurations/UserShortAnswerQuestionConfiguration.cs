using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities.UserQuestionTypes;
using QuizApp.Core.ValueObjects;

namespace QuizApp.Infrastructure.DAL.Configurations;

public class UserShortAnswerQuestionConfiguration : IEntityTypeConfiguration<UserShortAnswerQuestion>
{
    public void Configure(EntityTypeBuilder<UserShortAnswerQuestion> builder)
    {
        builder.Property(x => x.ShortAnswer)
            .HasConversion(x => x.Value, x => new ShortAnswer(x));
    }
}