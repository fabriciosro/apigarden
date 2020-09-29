using Dapper.Contrib.Extensions;
using Garden.Domain.Entities;
using Garden.Domain.Interfaces;
using Garden.Infra.Data.Configuration;
using Garden.Infra.Data.Standard;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Garden.Infra.Data.Repository
{
    public class TreeRepository : DomainRepository, IRepositoryTree
    {
        public TreeRepository(IDatabaseFactory databaseOptions) : base(databaseOptions)
        {
        }

        public TreeRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }

        public void Remove(Tree obj) =>
            connection.Delete(obj);

        public void Save(Tree obj)
        {
            if (obj.Id == 0)
                connection.Insert(obj);
            else
                connection.Update(obj);
        }

        public Tree GetById(int id) =>
            connection.Get<Tree>(id);

        public IList<Tree> GetAll() =>
            connection.GetAll<Tree>().ToList();

    }
}
