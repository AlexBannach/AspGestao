using Gestao.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Gestao.Data.Endpoints
{
    public static class CompanyEndpoints
    {
        public static void MapCompanyEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/companies", async (
                ICompanyRepository repository,
                [FromQuery] Guid applicationUserId,
                [FromQuery] int pageIndex,
                [FromQuery] string searchWord,
                IConfiguration config
            ) =>
            {
                var pageSize = config.GetValue<int>("Pagination:PageSize");
                var data = await repository.GetAll(applicationUserId, pageIndex, pageSize, searchWord);
                return Results.Ok(data);
            });
        }
    }
}