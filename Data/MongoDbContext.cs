using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ChatbotAPI.Models;

namespace ChatbotAPI.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDBConnection"));
            _database = client.GetDatabase("chatbotdb");
        }

        public IMongoCollection<Message> Messages => _database.GetCollection<Message>("Messages");
    }
}
