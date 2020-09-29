using Garden.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garden.Domain.Interfaces
{
    public interface IServiceSpecie
    {
        SpecieModel Insert(CreateSpecieModel specieModel);
        SpecieModel Update(int id, UpdateSpecieModel specieModel);
        void Delete(int id);
        SpecieModel RecoverById(int id);
        Task<IEnumerable<SpecieModel>> GetAllAsync();
        IEnumerable<SpecieModel> RecoverAll();
    }
}
