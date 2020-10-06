using Dapper;
using Dapper.Contrib.Extensions;
using Garden.Domain.Entities;
using Garden.Domain.Interfaces;
using Garden.Infra.Data.Configuration;
using Garden.Infra.Data.Standard;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Garden.Infra.Data.Repository
{
    public class HarvestRepository : DomainRepository, IRepositoryHarvest
    {
        public HarvestRepository(IDatabaseFactory databaseOptions) : base(databaseOptions)
        {
        }

        public HarvestRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }

        public void Remove(Harvest obj) =>
            connection.Delete(obj);

        public void Save(Harvest obj)
        {
            if (obj.Id == 0)
                connection.Insert(obj);
            else
                connection.Update(obj);
        }

        public async Task<Harvest> GetByIdAsync(int id)
        {
            string query = $" SELECT Harvest.Id, Harvest.Information, Harvest.HarvestDate, " +
                $" Harvest.GrossWeight, Harvest.TreeId, Tree.Id, Tree.Information, Tree.TreeAge, Tree.SpecieId " +
                $" FROM Harvest " +
                $" inner join Tree on Tree.Id = Harvest.TreeId " +
                $" where Harvest.Id = {id} ";

            var entity = await connection.QueryAsync<Harvest, Tree, Harvest>
            (query, (harvest, tree) =>
            {
                if (tree != null)
                {
                    harvest.Tree = tree;
                }
                return harvest;

            }, transaction: transaction);

            return entity.FirstOrDefault();
        }

        public IList<Harvest> GetAll() =>
            connection.GetAll<Harvest>().ToList();

        public async Task<IEnumerable<Harvest>> GetAllAsync()
        {
            string query = $" SELECT Harvest.Id, Harvest.Information, Harvest.HarvestDate, " +
                $" Harvest.GrossWeight, Harvest.TreeId, Tree.Id, Tree.Information, Tree.TreeAge, Tree.SpecieId " +
                $" FROM Harvest " +
                $" inner join Tree on Tree.Id = Harvest.TreeId ";

            var entity = await connection.QueryAsync<Harvest, Tree, Harvest>
            (query, (harvest, tree) =>
            {
                if (tree != null)
                {
                    harvest.Tree = tree;
                }
                return harvest;

            }, transaction: transaction);

            return entity;
        }
    }
}
