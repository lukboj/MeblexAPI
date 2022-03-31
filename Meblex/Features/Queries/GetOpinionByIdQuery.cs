using Meblex.ModelsDTO;
using Meblex.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Meblex.Features.Queries
{
    public class GetOpinionByIdQuery : IRequest<OpinionDTO>
    {
        public int id { get; set; }

        public class GetOpinionByIdQueryHanlder : IRequestHandler<GetOpinionByIdQuery, OpinionDTO>
        {
            private readonly IOpinionService opinionService;

            public GetOpinionByIdQueryHanlder(IOpinionService opinionService)
            {
                this.opinionService = opinionService;
            }

            public async Task<OpinionDTO> Handle(GetOpinionByIdQuery request, CancellationToken cancellationToken)
            {
                return await opinionService.GetOpinionById(request.id);
            }
        }
    }
}
