using Gestao.Domain;
using Gestao.Client.Libraries.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Data.Repositories
{
    public interface IAccountRepository
    {
        Task Add(Account account);
        Task Delete(int id);
        Task<PaginatedList<Account>> GetAll(int companyId, int pageIndex, int pageSize);
        Task<List<Account>> GetAll(int companyId);
        Task<Account?> GetById(int id);
        Task Update(Account account);
    }

    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Account>> GetAll(int companyId, int pageIndex, int pageSize)
        {
            var query = _context.Accounts.Where(c => c.CompanyId == companyId).AsQueryable();
            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<Account>(items, pageIndex, (int)Math.Ceiling((double)totalCount / pageSize));
        }
        public async Task<List<Account>> GetAll(int companyId)
        {
            return await _context.Accounts.Where(c => c.CompanyId == companyId).ToListAsync();
        }
        public async Task<Account?> GetById(int id)
        {
            return await _context.Accounts.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task Add(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var account = await GetById(id);
            if (account is not null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}