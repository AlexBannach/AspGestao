using Gestao.Domain;
using Gestao.Domain.Model.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
        public DbSet<DocumentAttachment> DocumentAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new DocumentAttachmentConfiguration());
            builder.ApplyConfiguration(new FinancialTransactionConfiguration());

            builder.Entity<FinancialTransaction>().Property(a => a.Repeat).HasConversion<string>();

        }
    }
}
