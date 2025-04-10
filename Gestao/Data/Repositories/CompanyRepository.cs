using Gestao.Domain;
using Gestao.Client.Libraries.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Data.Repositories
{
    public interface ICompanyRepository
    {
        Task Add(Company company);
        Task Delete(int id);
        Task<PaginatedList<Company>> GetAll(Guid applicationUserId, int pageIndex, int pageSize);
        Task<Company?> GetById(int id);
        Task Update(Company company);
    }

    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Company>> GetAll(Guid applicationUserId, int pageIndex, int pageSize)
        {
            var query = _context.Companies.Where(c => c.UserId == applicationUserId.ToString()).AsQueryable();
            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<Company>(items, pageIndex, (int)Math.Ceiling((double)totalCount / pageSize));
        }

        public async Task<Company?> GetById(int id)
        {
            return await _context.Companies.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task Add(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var company = await GetById(id);
            if (company is not null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }
    }
}