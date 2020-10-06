using Flunt.Validations;
using Garden.Domain.Interfaces;
using Garden.Domain.Models;
using Garden.Infra.Shared.Contexts;
using Garden.Infra.Shared.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garden.Service.Services
{
    public class HarvestService : IServiceHarvest
    {
        private readonly IRepositoryHarvest _repositoryHarvest;
        private readonly NotificationContext _notificationContext;

        public HarvestService(IRepositoryHarvest repositoryHarvest, NotificationContext notificationContext)
        {
            _repositoryHarvest = repositoryHarvest;
            _notificationContext = notificationContext;
        }

        public IEnumerable<HarvestModel> RecoverAll()
        {
            var harvests = _repositoryHarvest.GetAll();
            return harvests.ConvertToHarvests();
        }

        public async Task<IEnumerable<HarvestModel>> RecoverAllAsync()
        {
            var harvests = await _repositoryHarvest.GetAllAsync();

            return harvests.Select(x => x).ToList().ConvertToHarvests();
        }

        public async Task<HarvestModel> RecoverByIdAsync(int id)
        {
            var harvest = await _repositoryHarvest.GetByIdAsync(id);

            if (harvest != null)
                return harvest.ConvertToHarvest();
            else 
                return null;
        }

        public void Delete(int id)
        {
            var harvest = _repositoryHarvest.GetByIdAsync(id);

            if (harvest.Result != null)
                _repositoryHarvest.Remove(harvest.Result);            
        }

        public HarvestModel Insert(CreateHarvestModel harvestModel)
        {
            var harvest = harvestModel.ConvertToHarvestEntity();
            _notificationContext.AddNotifications(harvest.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryHarvest.Save(harvest);

            return harvest.ConvertToHarvest();
        }

        public HarvestModel Update(int id, UpdateHarvestModel harvestModel)
        {
            if (id != harvestModel.Id)
            {
                _notificationContext.AddNotifications(new Contract().AreNotEquals(id, harvestModel.Id, nameof(id), "Harvest not found."));

                return default;
            }

            var harvest = harvestModel.ConvertToHarvestEntity();

            _notificationContext.AddNotifications(harvest.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryHarvest.Save(harvest);
            return harvest.ConvertToHarvest();
        }
    }
}
