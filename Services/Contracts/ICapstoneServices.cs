using CapstoneGenerator.Server.Data;
using CapstoneGenerator.Server.Models;


namespace CapstoneGenerator.Server.Services.Contracts
{
    public interface ICapstoneServices
    {
        Task<IEnumerable<Capstones>> GetAllCapstones();
        Task<Capstones> GetCapstonesById(int id);
        Task<Capstones> AddCapstones(Capstones capstones);
        Task<Capstones> UpdateCapstones(int id, Capstones capstones);
        Task RemoveCapstones(int id);
    }
}
