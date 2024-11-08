using CapstoneGenerator.Server.Models;

namespace CapstoneGenerator.Server.Repositories.Contracts
{
    public interface ICapstoneRepository
    {
        Task<IEnumerable<Capstones>> GetAll();
        Task<Capstones> GetById(int id);
        Task<Capstones> Add(Capstones capstones);
        Task<Capstones> Update(Capstones capstones);
        Task Remove(int id);
    }
}
