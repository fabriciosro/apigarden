using System.Data;

namespace Garden.Infra.Data.Configuration
{
    public interface IDatabaseFactory
    {
        IDbConnection GetConnection { get; }
    }
}
