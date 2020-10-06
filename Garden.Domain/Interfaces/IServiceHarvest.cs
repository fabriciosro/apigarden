using Garden.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garden.Domain.Interfaces
{
    public interface IServiceHarvest
    {
        HarvestModel Insert(CreateHarvestModel harvestModel);
        HarvestModel Update(int id, UpdateHarvestModel harvestModel);
        void Delete(int id);
        Task<HarvestModel> RecoverByIdAsync(int id);
        IEnumerable<HarvestModel> RecoverAll();
        Task<IEnumerable<HarvestModel>> RecoverAllAsync();
    }
}
