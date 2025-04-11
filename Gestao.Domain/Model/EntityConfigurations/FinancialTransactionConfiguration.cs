using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Domain.Model.EntityConfigurations
{
    public class FinancialTransactionConfiguration : IEntityTypeConfiguration<FinancialTransaction>
    {
        public void Configure(EntityTypeBuilder<FinancialTransaction> builder)
        {
            // Chave primária
            builder.HasKey(ft => ft.Id);

            // Propriedades
            builder.Property(ft => ft.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(ft => ft.ReferenceDate)
                .IsRequired();

            builder.Property(ft => ft.DueDate)
                .IsRequired();

            builder.Property(ft => ft.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(ft => ft.Repeat)
                .IsRequired();

            builder.Property(ft => ft.RepeatTimes)
                .IsRequired();

            builder.Property(ft => ft.InterestPenalty)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(ft => ft.Discount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(ft => ft.PaymentDate)
                .IsRequired();

            builder.Property(ft => ft.AmoutPaid)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(ft => ft.Observation)
                .HasMaxLength(500);

            builder.Property(ft => ft.CreatedAt)
                .IsRequired();

            // Relacionamento com Company
            builder.HasOne(ft => ft.Company)
                .WithMany()
                .HasForeignKey(ft => ft.CompanyId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relacionamento com Account
            builder.HasOne(ft => ft.Account)
                .WithMany()
                .HasForeignKey(ft => ft.AccountId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relacionamento com Category
            builder.HasOne(ft => ft.Category)
                .WithMany()
                .HasForeignKey(ft => ft.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relacionamento com Documents
            builder.HasMany(ft => ft.Documents)
                .WithOne(da => da.FinancialTransaction)
                .HasForeignKey(da => da.FinancialTransactionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento com ApplicationUser
            builder.HasOne(ft => ft.User)
                .WithMany()
                .HasForeignKey(ft => ft.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                // Enum mapeado para string
            builder.Property(ft => ft.TypeFinancialTransaction)
                .IsRequired()
                .HasConversion<string>();

            // Enum mapeado para string
            builder.Property(ft => ft.Repeat)
                .IsRequired()
                .HasConversion<string>();
        }
    }
}