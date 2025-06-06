using Gestao.Domain;
using Gestao.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Data.Repositories
{

    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Document?> GetById(int id)
        {
            return await _context.Documents.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task Add(Document entity)
        {
            _context.Documents.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Document entity)
        {
            _context.Documents.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity is not null)
            {
                _context.Documents.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}