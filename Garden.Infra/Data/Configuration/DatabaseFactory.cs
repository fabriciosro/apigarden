using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Data;

namespace Garden.Infra.Data.Configuration
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private IOptions<DataSettings> _dataSettings;
        public IDbConnection GetConnection => new MySqlConnection(_dataSettings.Value.ContextGarden);

        public DatabaseFactory(IOptions<DataSettings> dataSettings)
        {
            _dataSettings = dataSettings;
        }
    }
}
