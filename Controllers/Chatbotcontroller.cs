using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ChatbotAPI.Services;

namespace ChatbotAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatbotController : ControllerBase
    {
        private readonly ChatbotService _chatbotService;

        public ChatbotController(ChatbotService chatbotService)
        {
            _chatbotService = chatbotService;
        }

        /// <summary>
        /// Get a response from the chatbot.
        /// </summary>
        /// <param name="userInput">The input from the user.</param>
        /// <returns>A response from the chatbot.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string userInput)
        {
            var response = await _chatbotService.GetResponseAsync(userInput);
            return Ok(response);
        }
    }
}
