using Gestao.Client.Libraries.Utilities;
using Gestao.Domain;
using Gestao.Domain.Model.Enums;
using Gestao.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Gestao.Client.Services
{
    public class FinancialTransactionService : IFinancialTransactionRepository
    {

        private readonly HttpClient _httpClient;

        public FinancialTransactionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task Add(FinancialTransaction entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAll(int companyId, TypeFinancialTransaction type, int pageIndex, int pageSize, string searchWord)
        {
            var url = $"/api/financialtransactions?companyId={companyId}&pageIndex={pageIndex}&searchWord={searchWord}&type={type}";
            var entities = await _httpClient.GetFromJsonAsync<PaginatedList<FinancialTransaction>>(url);

            return entities!;
        }

        public Task<FinancialTransaction?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(FinancialTransaction entity)
        {
            throw new NotImplementedException();
        }
    }
}