using Garden.Infra.Data.Configuration;
using System;
using System.Data;

namespace Garden.Infra.Data.Standard
{
    public abstract class DomainRepository : IDomainRepository
    {
        protected readonly IDbConnection connection;
        protected IDbTransaction transaction { get; private set; }

        protected DomainRepository(IDatabaseFactory databaseOptions)
        {
            connection = databaseOptions.GetConnection;
            connection.Open();
        }

        protected DomainRepository(IDbConnection dbConnection, IDbTransaction dbtransaction = null)
        {
            connection = dbConnection;

            if (connection.State != ConnectionState.Open)
                connection.Open();
            
            transaction = dbtransaction;
        }
        protected void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();

            GC.SuppressFinalize(this);
        }

    }
}
