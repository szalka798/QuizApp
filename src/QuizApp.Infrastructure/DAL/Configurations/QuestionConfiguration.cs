using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities.QuestionTypes;
using QuizApp.Core.ValueObjects;

namespace QuizApp.Infrastructure.DAL.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new QuestionId(x));
        builder.Property(x => x.Title)
            .HasConversion(x => x.Value, x => new Title(x));

        builder.HasDiscriminator<string>("Type")
            .HasValue<ShortAnswerQuestion>(nameof(ShortAnswerQuestion))
            .HasValue<SingleChoiceQuestion>(nameof(SingleChoiceQuestion));

    }
}