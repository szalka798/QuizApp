using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities.QuestionTypes;
using QuizApp.Core.Entities.UserQuestionTypes;
using QuizApp.Core.ValueObjects;

namespace QuizApp.Infrastructure.DAL.Configurations;

public class UserSingleChoiceQuestionConfiguration : IEntityTypeConfiguration<UserSingleChoiceQuestion>
{
    public void Configure(EntityTypeBuilder<UserSingleChoiceQuestion> builder)
    {
        builder.HasOne<SelectAnswer>().WithMany().HasForeignKey(x => x.SeletcedAnswerId);
        builder.Property(x => x.SeletcedAnswerId)
            .HasConversion(x => x.Value, x => new SelectAnswerId(x));
    }
}