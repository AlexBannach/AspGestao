using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Domain.Model.EntityConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            // Chave primária
            builder.HasKey(a => a.Id);

            // Propriedades
            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Balance)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(a => a.BalanceDate)
                .IsRequired();

            // Relacionamento com a entidade Company
            builder.HasOne(a => a.Company)
                .WithMany()
                .HasForeignKey(a => a.CompanyId)
                .OnDelete(DeleteBehavior.SetNull); // Define o comportamento de exclusão como "SetNull"
        }
    }
}