using Garden.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garden.Domain.Interfaces
{
    public interface IRepositorySpecie
    {
        Task<IEnumerable<Specie>> GetAllAsync();
        void Save(Specie obj);
        void Remove(Specie obj);
        Specie GetById(int id);
        IList<Specie> GetAll();
    }
}
