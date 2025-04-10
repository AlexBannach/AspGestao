using Gestao.Domain;
using Gestao.Client.Libraries.Utilities;
using Microsoft.EntityFrameworkCore;


namespace Gestao.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task Add(Category category);
        Task Delete(int id);
        Task<PaginatedList<Category>> GetAll(int companyId, int pageIndex, int pageSize);
        Task<List<Category>> GetAll(int companyId);
        Task<Category?> GetById(int id);
        Task Update(Category category);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Category>> GetAll(int companyId, int pageIndex, int pageSize)
        {
            var query = _context.Categorys.Where(c => c.CompanyId == companyId).AsQueryable();
            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<Category>(items, pageIndex, (int)Math.Ceiling((double)totalCount / pageSize));
        }
        public async Task<List<Category>> GetAll(int companyId)
        {
            return await _context.Categorys.Where(c => c.CompanyId == companyId).ToListAsync();
        }
        public async Task<Category?> GetById(int id)
        {
            return await _context.Categorys.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task Add(Category category)
        {
            _context.Categorys.Add(category);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Category category)
        {
            _context.Categorys.Update(category);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var category = await GetById(id);
            if (category is not null)
            {
                _context.Categorys.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }

}