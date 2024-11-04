using CSharpie.Tasks.Application.Common.Interfaces;
using CSharpie.Tasks.Application.Employees.Queries.GetEmployeesWithPagination;
using CSharpie.Tasks.Domain.Entities;

namespace CSharpie.Tasks.Application.Employees.Queries.GetEmployee;

public record GetEmployeeByIdQuery : IRequest<EmployeeBriefDto>
{
    public int Id { get; init; }
}

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeBriefDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEmployeeByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EmployeeBriefDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Employees
            .ProjectTo<EmployeeBriefDto>(_mapper.ConfigurationProvider)
            .FirstAsync(i => i.Id == request.Id, cancellationToken);
        return result;
    }
}
