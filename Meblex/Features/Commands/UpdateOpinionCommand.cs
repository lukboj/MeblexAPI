using Meblex.Features.Queries;
using Meblex.ModelsDTO;
using Meblex.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Meblex.Features.Commands
{
    public class UpdateOpinionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public class UpdateOpinionCommandHandler : IRequestHandler<UpdateOpinionCommand, int>
        {
            private readonly IOpinionService opinionService;

            public UpdateOpinionCommandHandler(IOpinionService _opinionService)
            {
                opinionService = _opinionService;
            }   

            public async Task<int> Handle(UpdateOpinionCommand request, CancellationToken cancellationToken)
            {

                var opinion = await opinionService.GetOpinionById(request.Id);

                if (opinion == null)
                {
                    return default;
                }
                
                    opinion.LastName = request.LastName;
                    opinion.FirstName = request.FirstName;
                    opinion.description = request.Description;

                    return await opinionService.UpdateOpinion(opinion);
                

            }
        }
    }
}
