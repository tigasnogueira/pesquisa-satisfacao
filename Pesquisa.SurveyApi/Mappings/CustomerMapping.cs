using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Mappings;

public class CustomerMapping : IEntityTypeConfiguration<CustomerModel>
{
    public void Configure(EntityTypeBuilder<CustomerModel> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.CustomerName).IsRequired().HasMaxLength(100);
        builder.Property(c => c.ContactName).IsRequired().HasMaxLength(100);
        builder.Property(c => c.CNPJ).IsRequired().HasMaxLength(14);
        builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Phone).HasMaxLength(20);
        builder.Property(c => c.Address).HasMaxLength(100);
        builder.Property(c => c.City).HasMaxLength(100);
        builder.Property(c => c.State).HasMaxLength(100);
        builder.Property(c => c.PostalCode).HasMaxLength(8);
        builder.Property(c => c.Country).HasMaxLength(100);
        builder.Property(c => c.Notes).HasMaxLength(100);
        builder.Property(c => c.BecameCustomerDate).IsRequired();
        builder.Property(c => c.Category).HasMaxLength(100);
        builder.Property(c => c.LastEvaluationDate).IsRequired();
        builder.Property(c => c.CreatedAt).IsRequired();
        builder.Property(c => c.UpdatedAt).IsRequired();
        builder.Property(c => c.IsActive).IsRequired();

        builder.HasMany(c => c.Evaluations) // Um cliente tem muitas avaliações
            .WithOne(e => e.Customer) // Uma avaliação pertence a um cliente
            .HasForeignKey(e => e.CustomerId); // Chave estrangeira para CustomerId

        builder.ToTable("Customer");
    }
}
