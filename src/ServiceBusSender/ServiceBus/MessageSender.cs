using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ServiceBusSender.ServiceBus
{
    public class MessageSender : IMessageSender
    {
        private readonly ILogger _logger;
        private readonly MessageSenderSettings _settings;

        public MessageSender(ILogger<MessageSender> logger, IOptions<MessageSenderSettings> settings)
        {
            _logger = logger;
            _settings = settings?.Value;
        }

        public Task SendMessageAsync(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
