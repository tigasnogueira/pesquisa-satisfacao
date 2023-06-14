using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Mappings;

public class EvaluationMapping : IEntityTypeConfiguration<EvaluationModel>
{
    public void Configure(EntityTypeBuilder<EvaluationModel> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.EvaluationDate).IsRequired();
        builder.Property(c => c.CustomerId).IsRequired();
        builder.Property(c => c.Score).IsRequired();
        builder.Property(c => c.Reason).IsRequired().HasMaxLength(100);
        builder.Property(c => c.CreatedAt).IsRequired();
        builder.Property(c => c.UpdatedAt).IsRequired();
        builder.Property(c => c.IsActive).IsRequired();

        builder.HasOne(e => e.Customer) // Uma avaliação pertence a um cliente
            .WithMany(c => c.Evaluations) // Um cliente tem muitas avaliações
            .HasForeignKey(e => e.CustomerId); // Chave estrangeira para CustomerId

        builder.ToTable("Evaluation");
    }
}
