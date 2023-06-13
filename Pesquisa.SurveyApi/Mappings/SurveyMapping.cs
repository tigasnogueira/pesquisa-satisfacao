using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Mappings;

public class SurveyMapping : IEntityTypeConfiguration<SurveyModel>
{
    public void Configure(EntityTypeBuilder<SurveyModel> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Description).IsRequired().HasMaxLength(100);
        builder.Property(c => c.CreatedAt).IsRequired();
        builder.Property(c => c.UpdatedAt).IsRequired();
        builder.Property(c => c.IsActive).IsRequired();
        builder.Property(c => c.Deleted).IsRequired();

        builder.HasMany(c => c.Questions).WithOne(c => c.Survey).HasForeignKey(c => c.SurveyId);

        builder.ToTable("Survey");
    }
}
