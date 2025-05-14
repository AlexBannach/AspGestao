using Gestao.Client.Libraries.Utilities;

namespace Gestao.Domain.Repositories.Interfaces
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
}