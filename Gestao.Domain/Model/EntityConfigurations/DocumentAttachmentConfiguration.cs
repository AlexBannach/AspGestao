using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Domain.Model.EntityConfigurations
{
    public class DocumentAttachmentConfiguration : IEntityTypeConfiguration<DocumentAttachment>
    {
        public void Configure(EntityTypeBuilder<DocumentAttachment> builder)
        {
            // Chave primária
            builder.HasKey(d => d.Id);

            // Propriedades
            builder.Property(d => d.Path)
                .IsRequired()
                .HasMaxLength(255); // Define um limite de caracteres para o caminho do arquivo

            builder.Property(d => d.CreatedAt)
                .IsRequired();

            // Relacionamento com FinancialTransaction
            builder.HasOne(d => d.FinancialTransaction)
                .WithMany()
                .HasForeignKey(d => d.FinancialTransactionId)
                .OnDelete(DeleteBehavior.SetNull); // Define o comportamento de exclusão como "SetNull"
        }
    }
}