using Abonesepeti.Entity.Entity;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Abonesepeti.DataAccess.MongoDb
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration config)
        {
            _database = new MongoClient(config.GetConnectionString("MongoDb")).GetDatabase("userDB");
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    }
}
