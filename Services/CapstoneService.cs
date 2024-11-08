using CapstoneGenerator.Server.Data;
using CapstoneGenerator.Server.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using CapstoneGenerator.Server.Repositories.Contracts;
using CapstoneGenerator.Server.Models;

namespace CapstoneGenerator.Server.Services
{
    public class CapstoneService : ICapstoneServices
    {
        private readonly ICapstoneRepository capstoneRepository;

        public CapstoneService
            (
                ICapstoneRepository capstoneRepository
            )
        {
            this.capstoneRepository = capstoneRepository;
        }


        public async Task<IEnumerable<Capstones>> GetAllCapstones()
        {
            return await capstoneRepository.GetAll();
        }

        public async Task<Capstones> GetCapstonesById(int Id)
        {
            return await capstoneRepository.GetById(Id);
        }


        public async Task<Capstones> AddCapstones([FromBody] Capstones capstones)
        {
            return await capstoneRepository.Add(capstones);
        }


        public async Task<Capstones> UpdateCapstones(int Id, [FromBody] Capstones capstones)
        {
            return await capstoneRepository.Update(capstones);
        }

        public async Task RemoveCapstones(int Id)
        {
            await capstoneRepository.Remove(Id);
        }
    }
}
