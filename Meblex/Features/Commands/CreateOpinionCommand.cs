using Meblex.Features.Queries;
using Meblex.ModelsDTO;
using Meblex.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Meblex.Features.Commands
{
    public class CreateOpinionCommand : IRequest<OpinionDTO>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public class CreateOpinionCommandHandler : IRequestHandler<CreateOpinionCommand, OpinionDTO>
        {
            private readonly IOpinionService opinionService;

            public CreateOpinionCommandHandler(IOpinionService opinionService)
            {
                this.opinionService = opinionService;
            }


            public Task<OpinionDTO> Handle(CreateOpinionCommand request, CancellationToken cancellationToken)
            {
                var opinion = new OpinionDTO()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    description = request.Description
                };
                return opinionService.CreateOpinion(opinion);
            }
        }
    }
}
