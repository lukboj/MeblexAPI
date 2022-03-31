using Meblex.ModelsDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meblex.Services.Interfaces
{
    public interface IOpinionService
    {
        Task<IEnumerable<OpinionDTO>> GetOpinionList();
        Task<OpinionDTO> GetOpinionById(int id);
        Task<OpinionDTO> CreateOpinion(OpinionDTO player);
        Task<int> UpdateOpinion(OpinionDTO player);
        Task<int> DeleteOpinion(OpinionDTO player);
    }
}
