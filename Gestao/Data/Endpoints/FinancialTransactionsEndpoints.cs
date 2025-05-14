using Gestao.Domain.Repositories.Interfaces;
using Gestao.Domain.Model.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Gestao.Data.Endpoints
{
    public static class FinancialTransactionsEndpoints
    {
        public static void MapFinancialTransactionsEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/financialtransactions", async (
                IFinancialTransactionRepository repository,
                [FromQuery] TypeFinancialTransaction type, 
                [FromQuery] int companyId,
                [FromQuery] int pageIndex,
                [FromQuery] string searchWord,
                IConfiguration config
            ) =>
            {
                var pageSize = config.GetValue<int>("Pagination:PageSize");
                var data = await repository.GetAll(companyId, type, pageIndex, pageSize, searchWord);
                return Results.Ok(data);
            });
        }
    }
}