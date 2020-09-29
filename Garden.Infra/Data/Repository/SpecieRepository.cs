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
    public class SpecieRepository : DomainRepository, IRepositorySpecie
    {
        public SpecieRepository(IDatabaseFactory databaseOptions) : base(databaseOptions)
        {
        }

        public SpecieRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }

        public async Task<IEnumerable<Specie>> GetAllAsync()
        {
            string query = $"SELECT Id, Information FROM Specie";

            return await connection.QueryAsync<Specie>(query, transaction: transaction);
        }

        public void Remove(Specie specie) => 
            connection.Delete(specie);

        public void Save(Specie obj)
        {
            if (obj.Id == 0)
                connection.Insert(obj);
            else
                connection.Update(obj);
        }

        public Specie GetById(int id) => 
            connection.Get<Specie>(id);

        public IList<Specie> GetAll() =>
            connection.GetAll<Specie>().ToList();
    }
}
