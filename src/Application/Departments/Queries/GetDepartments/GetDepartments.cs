using CSharpie.Tasks.Application.Common.Interfaces;
using CSharpie.Tasks.Application.Common.Security;
using CSharpie.Tasks.Domain.Entities;

namespace CSharpie.Tasks.Application.Departments.Queries.GetDepartments;

[Authorize]

public record GetDepartmentsQuery : IRequest<DepartmentsVM>;

public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, DepartmentsVM>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDepartmentsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DepartmentsVM> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        return new DepartmentsVM
        {
            Departments = await _context.Departments
                .AsNoTracking()
                .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
                // .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}
