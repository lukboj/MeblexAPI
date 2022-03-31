using MeblexData.Data;
using MeblexData.Interfaces;
using MeblexData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Repositories
{
    public class OpinionRepository : IOpinionRepository
    {
        private readonly AppDbContext appDbContext;

        public OpinionRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Opinion> AddOpinion(Opinion opinion)
        {
            appDbContext.Opinions.Add(opinion);
            await appDbContext.SaveChangesAsync();
            return opinion;
        }

        public async Task<int> DeleteOpinion(Opinion opinion)        {

            appDbContext.Opinions.Remove(opinion);
            return await appDbContext.SaveChangesAsync(); 
        }


        public async Task<Opinion> GetOpinionById(int opinionid)
        {
            return await  appDbContext.Opinions.AsNoTracking().FirstOrDefaultAsync(a=> a.opinionid == opinionid);
        }

        public async Task<IEnumerable<Opinion>> GetOpinions() => await appDbContext.Opinions.ToListAsync();

        public async Task<int> UpdateOpinion(Opinion opinion)
        {
           
            appDbContext.Opinions.Update(opinion);
            return await appDbContext.SaveChangesAsync();
        }
    }
}
