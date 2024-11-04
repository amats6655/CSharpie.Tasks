using CSharpie.Tasks.Application.Common.Interfaces;
using CSharpie.Tasks.Application.Common.Security;

namespace CSharpie.Tasks.Application.Positions.Queries.GetPositions;

[Authorize]
public record GetPositionsQuery : IRequest<PositionsVM>;

public class GetPositionsQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetPositionsQuery, PositionsVM>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<PositionsVM> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
    {
        return new PositionsVM
        {
            Positions = await _context.Positions
                .AsNoTracking()
                .ProjectTo<PositionDto>(_mapper.ConfigurationProvider)
                // .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}
