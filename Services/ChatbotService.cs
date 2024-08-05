using System.Threading.Tasks;
using ChatbotAPI.Data;
using ChatbotAPI.Models;

namespace ChatbotAPI.Services
{
    public class ChatbotService
    {
        private readonly ChatbotContext _sqlContext;
        private readonly MongoDbContext _mongoContext;

        public ChatbotService(ChatbotContext sqlContext, MongoDbContext mongoContext)
        {
            _sqlContext = sqlContext;
            _mongoContext = mongoContext;
        }

        public async Task<Message> GetResponseAsync(string userInput)
        {
            var response = new Message
            {
                Text = "This is a response from the chatbot.",
                Timestamp = DateTime.Now
            };

            _sqlContext.Messages.Add(response);
            await _sqlContext.SaveChangesAsync();

            await _mongoContext.Messages.InsertOneAsync(response);

            return response;
        }
    }
}
