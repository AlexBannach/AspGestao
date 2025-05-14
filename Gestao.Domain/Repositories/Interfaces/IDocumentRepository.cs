
namespace Gestao.Domain.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        Task Add(Document entity);
        Task Delete(int id);
        Task<Document?> GetById(int id);
        Task Update(Document entity);
    }
}