using CSharpie.Tasks.Application.Catalog.Movies.Queries;
using CSharpie.Tasks.Application.Common.Models;

namespace CSharpie.Tasks.Web.Endpoints;

public class Movies : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetMoviesWithPagination);
    }

    public Task<PaginatedList<MovieDto>> GetMoviesWithPagination(ISender sender, [AsParameters] GetMoviesWithPaginationQuery query)
    {
        return sender.Send(query);
    }
}
