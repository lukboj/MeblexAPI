using AutoMapper;
using Meblex.Features.Queries;
using Meblex.ModelsDTO;
using Meblex.Services.Interfaces;
using MeblexData.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Meblex.Features.Commands
{
    public class DeleteOpinionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public class DeleteOpinionCommandHandler : IRequestHandler<DeleteOpinionCommand, int>
        {
            private readonly IOpinionService opinionService;

            public DeleteOpinionCommandHandler(IOpinionService _opinionService)
            {
                opinionService = _opinionService;
            }



            public async Task<int> Handle(DeleteOpinionCommand request, CancellationToken cancellationToken)
            {
                var opinion = await opinionService.GetOpinionById(request.Id);

                if (opinion == null)
                    return default;

                return await opinionService.DeleteOpinion(opinion);
            }
        }
    }
}
