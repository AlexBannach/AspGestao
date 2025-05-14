using Gestao.Domain;
using Gestao.Client.Libraries.Utilities;


namespace Gestao.Domain.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task Add(Account account);
        Task Delete(int id);
        Task<PaginatedList<Account>> GetAll(int companyId, int pageIndex, int pageSize, string searchWord);
        Task<List<Account>> GetAll(int companyId);
        Task<Account?> GetById(int id);
        Task Update(Account account);
    }
}