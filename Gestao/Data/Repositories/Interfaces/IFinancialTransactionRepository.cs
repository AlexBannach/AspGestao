using Gestao.Client.Libraries.Utilities;
using Gestao.Domain;
using Gestao.Domain.Model.Enums;


namespace Gestao.Data.Repositories.Interfaces
{
    public interface IFinancialTransactionRepository
    {
        Task Add(FinancialTransaction entity);
        Task Delete(int id);
        Task<PaginatedList<FinancialTransaction>> GetAll(int companyId, TypeFinancialTransaction type, int pageIndex, int pageSize, string searchWord);
        Task<FinancialTransaction?> GetById(int id);
        Task Update(FinancialTransaction entity);
    }
}