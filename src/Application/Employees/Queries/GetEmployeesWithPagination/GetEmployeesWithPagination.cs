using CSharpie.Tasks.Application.Common.Interfaces;
using CSharpie.Tasks.Application.Common.Mappings;
using CSharpie.Tasks.Application.Common.Models;

namespace CSharpie.Tasks.Application.Employees.Queries.GetEmployeesWithPagination;

public record GetEmployeesWithPaginationQuery : IRequest<PaginatedList<EmployeeBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class
    GetEmployeesWithPaginationQueryHandler : IRequestHandler<GetEmployeesWithPaginationQuery,
    PaginatedList<EmployeeBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEmployeesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<EmployeeBriefDto>> Handle(GetEmployeesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _context.Employees
            .OrderBy(x => x.LastName)
            .ProjectTo<EmployeeBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        return result;
    }
}
