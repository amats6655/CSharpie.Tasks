using CSharpie.Tasks.Application.Common.Interfaces;
using CSharpie.Tasks.Application.Common.Mappings;
using CSharpie.Tasks.Application.Common.Models;

namespace CSharpie.Tasks.Application.Catalog.Movies.Queries;

public record GetMoviesWithPaginationQuery : IRequest<PaginatedList<MovieDto>>
{
    public int pageNumber { get; init; } = 1;
    public int pageSize { get; init; } = 10;
}

public class
    GetMoviesWithPaginationQueryHandler : IRequestHandler<GetMoviesWithPaginationQuery, PaginatedList<MovieDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMoviesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<MovieDto>> Handle(GetMoviesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Movies
            .OrderBy(x => x.Title)
            .ProjectTo<MovieDto>(_mapper.ConfigurationProvider, cancellationToken)
            .PaginatedListAsync(request.pageNumber, request.pageSize);
    }
}
