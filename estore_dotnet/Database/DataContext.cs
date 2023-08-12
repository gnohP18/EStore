using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estore_dotnet.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using dbShoes = estore_dotnet.Databases.Shoes;

namespace estore_dotnet.Databases
{
    public class DataContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly MongoClient _clientMongo;
        
        public DataContext(IOptions<EstoreDatabaseSetting> estoreDatabaseSettings)
        {
             _clientMongo = new MongoClient(estoreDatabaseSettings.Value.ConnectionString);
            _mongoDatabase = _clientMongo.GetDatabase(estoreDatabaseSettings.Value.DatabaseName); 
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _mongoDatabase.GetCollection<T>(collectionName);
        }
    }
}   