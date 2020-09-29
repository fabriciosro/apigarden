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
    public class SpecieService : IServiceSpecie
    {
        private readonly IRepositorySpecie _repositorySpecie;
        private readonly NotificationContext _notificationContext;

        public SpecieService(IRepositorySpecie repositorySpecie, NotificationContext notificationContext)
        {
            _repositorySpecie = repositorySpecie;
            _notificationContext = notificationContext;
        }

        public async Task<IEnumerable<SpecieModel>> GetAllAsync()
        {
            var species = await _repositorySpecie.GetAllAsync();

            return species.Select(x => x).ToList().ConvertToSpecies();
        }

        public IEnumerable<SpecieModel> RecoverAll()
        {
            var Species = _repositorySpecie.GetAll();
            return Species.ConvertToSpecies();
        }

        public SpecieModel RecoverById(int id)
        {
            var Specie = _repositorySpecie.GetById(id);
            return Specie.ConvertToSpecie();
        }

        public void Delete(int id)
        {
            var Specie = _repositorySpecie.GetById(id);
            _repositorySpecie.Remove(Specie);
        }

        public SpecieModel Insert(CreateSpecieModel SpecieModel)
        {
            var Specie = SpecieModel.ConvertToSpecieEntity();
            _notificationContext.AddNotifications(Specie.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositorySpecie.Save(Specie);

            return Specie.ConvertToSpecie();
        }

        public SpecieModel Update(int id, UpdateSpecieModel SpecieModel)
        {
            if (id != SpecieModel.Id)
            {
                _notificationContext.AddNotifications(new Contract().AreNotEquals(id, SpecieModel.Id, nameof(id), "Specie not found."));

                return default;
            }

            var Specie = SpecieModel.ConvertToSpecieEntity();

            _notificationContext.AddNotifications(Specie.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositorySpecie.Save(Specie);
            return Specie.ConvertToSpecie();
        }
    }
}
