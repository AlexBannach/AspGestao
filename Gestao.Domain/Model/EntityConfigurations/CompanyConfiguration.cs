using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Domain.Model.EntityConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            // Chave primária
            builder.HasKey(c => c.Id);

            // Propriedades obrigatórias
            builder.Property(c => c.LegalName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.TradeName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.CNPJ)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(14);
            // Adicionando restrição de unicidade para CNPJ
            builder.HasIndex(c => c.CNPJ)
                .IsUnique();

            builder.Property(c => c.PostalCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.State)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Neighborhood)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Number)
                .IsRequired()
                .HasMaxLength(10);

            // Propriedades opcionais
            builder.Property(c => c.Complement)
                .HasMaxLength(100);

            builder.Property(c => c.Phone)
                .HasMaxLength(15);

            // Propriedade de data
            builder.Property(c => c.CreatedAt)
                .IsRequired();

            // Relacionamento com ApplicationUser
            builder.HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Exclui a empresa se o usuário for excluído
        }
    }
}