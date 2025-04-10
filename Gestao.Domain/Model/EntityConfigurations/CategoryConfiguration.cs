using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Domain.Model.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Chave primária
            builder.HasKey(c => c.Id);

            // Propriedades
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50); // Define um limite de caracteres para o nome

            builder.Property(c => c.Description)
                .HasMaxLength(250); // Define um limite de caracteres para a descrição

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            builder.Property(c => c.UpdatedAt)
                .IsRequired();
        }
    }
}