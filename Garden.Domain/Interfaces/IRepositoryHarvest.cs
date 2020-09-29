using Garden.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garden.Domain.Interfaces
{
    public interface IRepositoryHarvest
    {
        IList<Harvest> GetAll();
        Task<IEnumerable<Harvest>> GetAllAsync();
        Harvest GetById(int id);
        void Save(Harvest obj);
        void Remove(Harvest obj);
    }
}
