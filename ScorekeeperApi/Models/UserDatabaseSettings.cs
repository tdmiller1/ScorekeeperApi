using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScorekeeperApi.Models
{
    // Identitcal naming to the appsettins.json file
    public class UserDatabaseSettings : IUserDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IUserDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
