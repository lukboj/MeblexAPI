using MeblexData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Interfaces
{
    public interface  IOpinionRepository
    {
        Task<IEnumerable<Opinion>> GetOpinions();

        Task<Opinion> AddOpinion(Opinion opinion);

        Task<int> UpdateOpinion(Opinion opinion);
        Task<int> DeleteOpinion(Opinion opinion);

        Task<Opinion> GetOpinionById(int opinionid);
    }
}
