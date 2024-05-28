using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Core.Entities;
using QuizApp.Core.ValueObjects;

namespace QuizApp.Infrastructure.DAL.Configurations;

public class UserQuizResultConfiguration : IEntityTypeConfiguration<UserQuizResult>
{
    public void Configure(EntityTypeBuilder<UserQuizResult> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new UserQuizResultId(x));
        builder.HasOne<Quiz>().WithMany().HasForeignKey(x => x.QuizId);
        builder.Property(x => x.QuizId)
            .IsRequired()
            .HasConversion(x => x.Value, x => new QuizId(x));
        builder.Property(x => x.TotalPoints)
            .IsRequired()
            .HasConversion(x => x.Value, x => new TotalPoints(x));
    }
}