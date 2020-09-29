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
    public class GroupTreeRepository : DomainRepository, IRepositoryGroupTree
    {
        public GroupTreeRepository(IDatabaseFactory databaseOptions) : base(databaseOptions)
        {
        }

        public GroupTreeRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }

        public void Remove(GroupTree obj) => 
            connection.Delete(obj);

        public void Save(GroupTree obj)
        {
            if (obj.Id == 0)
                connection.Insert(obj);
            else
                connection.Update(obj);
        }

        public GroupTree GetById(int id) =>
            connection.Get<GroupTree>(id);

        public IList<GroupTree> GetAll() =>
            connection.GetAll<GroupTree>().ToList();
    }
}
