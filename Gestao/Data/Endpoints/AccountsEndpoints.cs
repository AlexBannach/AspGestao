using Gestao.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Gestao.Data.Endpoints
{
    public static class AccountsEndpoints
    {
        public static void MapAccountsEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/accounts", async (
                IAccountRepository repository,
                [FromQuery] int companyId,
                [FromQuery] int pageIndex,
                [FromQuery] string searchWord,
                IConfiguration config
            ) =>
            {
                var pageSize = config.GetValue<int>("Pagination:PageSize");
                var data = await repository.GetAll(companyId, pageIndex, pageSize, searchWord);
                return Results.Ok(data);
            });
        }
    }
}