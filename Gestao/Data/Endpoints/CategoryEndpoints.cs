using Gestao.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Gestao.Data.Endpoints;
   public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/categories", async (
            ICategoryRepository repository,
            [FromQuery] int companyId,
            [FromQuery] int pageIndex,
            IConfiguration config
        ) =>
        {
            var pageSize = config.GetValue<int>("Pagination:PageSize");
            var data = await repository.GetAll(companyId, pageIndex, pageSize);
            return Results.Ok(data);
        });
    }
}