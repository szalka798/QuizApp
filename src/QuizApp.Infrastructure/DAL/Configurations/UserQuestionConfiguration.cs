using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities.UserQuestionTypes;
using QuizApp.Core.ValueObjects;

namespace QuizApp.Infrastructure.DAL.Configurations;

public class UserQuestionConfiguration : IEntityTypeConfiguration<UserQuestion>
{
    public void Configure(EntityTypeBuilder<UserQuestion> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new UserQuestionId(x));
        builder.Property(x => x.ScoredPoints)
            .HasConversion(x => x.Value, x => new ScoredPoints(x));
        builder.Property(x => x.IsCorrect)
            .HasConversion(x => x.Value, x => new IsCorrect(x));

        builder.HasDiscriminator<string>("type")
            .HasValue<UserShortAnswerQuestion>(nameof(UserShortAnswerQuestion))
            .HasValue<UserSingleChoiceQuestion>(nameof(UserSingleChoiceQuestion));

    }
}