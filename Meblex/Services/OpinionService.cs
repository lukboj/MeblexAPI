using AutoMapper;
using Meblex.ModelsDTO;
using Meblex.Services.Interfaces;
using MeblexData.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeblexData.Interfaces;
using MeblexData.Models;

namespace Meblex.Services
{
    public class OpinionService : IOpinionService
    {
        private readonly IOpinionRepository opinionRepository;

        private readonly IMapper mapper;
        public OpinionService(IOpinionRepository _opinionRepository, IMapper _mapper)
        {
            opinionRepository = _opinionRepository;
            mapper = _mapper;
        }
        public async Task<OpinionDTO> CreateOpinion(OpinionDTO opinion)
        {
            var opiniontocreate = mapper.Map<Opinion>(opinion);

            await opinionRepository.AddOpinion(opiniontocreate);

            return opinion;
            
        }

        public Task<int> DeleteOpinion(OpinionDTO opinion)
        {
            return opinionRepository.DeleteOpinion(mapper.Map<Opinion>(opinion));
           
        }

        public async Task<OpinionDTO> GetOpinionById(int id)
        {
            var opinion = await opinionRepository.GetOpinionById(id);
            var opiniondto = mapper.Map<OpinionDTO>(opinion);
            return opiniondto;

        }

        public async Task<IEnumerable<OpinionDTO>> GetOpinionList()
        {
            var list = await opinionRepository.GetOpinions();

            var listdto = mapper.Map<IEnumerable<OpinionDTO>>(list);

            return listdto;
        }

        public Task<int> UpdateOpinion(OpinionDTO opinion)
        {

            return opinionRepository.UpdateOpinion(mapper.Map<Opinion>(opinion));
        }
    }
}
