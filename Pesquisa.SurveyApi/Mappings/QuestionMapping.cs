using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Mappings;

public class QuestionMapping : IEntityTypeConfiguration<QuestionModel>
{
    public void Configure(EntityTypeBuilder<QuestionModel> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Description).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Type).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Options).IsRequired().HasMaxLength(100);
        builder.Property(c => c.CreatedAt).IsRequired();
        builder.Property(c => c.UpdatedAt).IsRequired();
        builder.Property(c => c.IsActive).IsRequired();
        builder.Property(c => c.Deleted).IsRequired();

        builder.HasOne(c => c.Survey).WithMany(c => c.Questions).HasForeignKey(c => c.SurveyId);

        builder.ToTable("Question");
    }
}
