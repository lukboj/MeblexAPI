using Meblex.ModelsDTO;
using Meblex.Services.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meblex.Features.Queries
{
    public class GetAllOpinionsQuery : IRequest<IEnumerable<OpinionDTO>>
    {
        public class GetAllOpinionsQueryHandler :IRequestHandler<GetAllOpinionsQuery, IEnumerable<OpinionDTO>>
        {
            private readonly IOpinionService opinionService;

            public GetAllOpinionsQueryHandler(IOpinionService _opinionService)
            {
                opinionService = _opinionService;
            }
            public async Task<IEnumerable<OpinionDTO>> Handle(GetAllOpinionsQuery query, CancellationToken cancellationToken)
            {
                return await opinionService.GetOpinionList();
            }
        }
    }
}
