using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.ServiceBus;

namespace ServiceBusSender.ServiceBus
{
    public class MessageSender : IMessageSender, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IClientFactory _factory;

        private IQueueClient Client => _factory?.Create(); 

        public MessageSender(IClientFactory factory, ILogger<MessageSender> logger)
        {
            _logger = logger;
            _factory = factory;
        }

        public async Task SendMessageAsync(string messageBody)
        {
            if (string.IsNullOrEmpty(messageBody))
                throw new ArgumentNullException(nameof(messageBody));

            // create message to send
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));
            _logger.LogInformation($"Sending message: {messageBody}");

            // send message to the queue
            await Client.SendAsync(message);
        }

        public async Task CloseAsync()
        {
            if(Client != null && !Client.IsClosedOrClosing)
                await Client.CloseAsync();
        }

        public void Dispose()
        {
            CloseAsync().Wait();
        }
    }
}
