using Gestao.Domain;
using Gestao.Client.Libraries.Utilities;
using Gestao.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Gestao.Domain.Model.Enums;

namespace Gestao.Data.Repositories
{

    public class FinancialTransactionRepository : IFinancialTransactionRepository
    {
        private readonly ApplicationDbContext _context;
        public FinancialTransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAll(int companyId, TypeFinancialTransaction type, int pageIndex, int pageSize, string searchWord = "")
        {
            var query = _context.FinancialTransactions
            .Where(c => c.CompanyId == companyId && c.TypeFinancialTransaction == type)
            .Where(c => c.Description.Contains(searchWord))
            .AsQueryable();
            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<FinancialTransaction>(items, pageIndex, (int)Math.Ceiling((double)totalCount / pageSize));
        }

        public async Task<FinancialTransaction?> GetById(int id)
        {
            return await _context.FinancialTransactions.OrderByDescending(a => a.ReferenceDate).Include(a => a.Documents).SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task Add(FinancialTransaction entity)
        {
            _context.FinancialTransactions.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(FinancialTransaction entity)
        {
            _context.FinancialTransactions.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity is not null)
            {
                _context.FinancialTransactions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}