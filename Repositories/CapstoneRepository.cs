using CapstoneGenerator.Server.Controllers;
using CapstoneGenerator.Server.Data.DbContext;
using CapstoneGenerator.Server.Repositories.Contracts;
using CapstoneGenerator.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneGenerator.Server.Repositories
{
    public class CapstoneRepository : ICapstoneRepository
    {
        private readonly WebApplicationDbContext dbContext;

        public CapstoneRepository
            (
                WebApplicationDbContext dbContext
            )
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Capstones>> GetAll()
        {
            return await dbContext.Capstones.ToListAsync();
        }

        public async Task<Capstones> GetById(int id)
        {
            return await dbContext.Capstones.FindAsync(id);
        }

        public async Task<Capstones> Add(Capstones capstones)
        {
            dbContext.Capstones.Add(capstones);
            await dbContext.SaveChangesAsync();
            return capstones;
        }

        public async Task<Capstones> Update(Capstones capstones)
        {
            dbContext.Capstones.Update(capstones);
            await dbContext.SaveChangesAsync();
            return capstones;
        }

        public async Task Remove(int id)
        {
            var capstones = await dbContext.Capstones.FindAsync(id);
            if (capstones != null)
            {
                dbContext.Capstones.Remove(capstones);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
