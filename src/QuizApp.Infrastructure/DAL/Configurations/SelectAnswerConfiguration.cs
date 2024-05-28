using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities.QuestionTypes;
using QuizApp.Core.ValueObjects;

namespace QuizApp.Infrastructure.DAL.Configurations;

public class SelectAnswerConfiguration : IEntityTypeConfiguration<SelectAnswer>
{
    public void Configure(EntityTypeBuilder<SelectAnswer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new SelectAnswerId(x));
        builder.Property(x => x.Content)
            .HasConversion(x => x.Value, x => new Content(x));
        builder.Property(x => x.IsCorrect)
            .HasConversion(x => x.Value, x => new IsCorrect(x));


    }
}