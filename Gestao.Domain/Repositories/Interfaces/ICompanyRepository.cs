using Gestao.Client.Libraries.Utilities;

namespace Gestao.Domain.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
         Task Add(Company company);
        Task Delete(int id);
        Task<PaginatedList<Company>> GetAll(Guid applicationUserId, int pageIndex, int pageSize, string searchWord);
        Task<Company?> GetById(int id);
        Task Update(Company company);
    }
}