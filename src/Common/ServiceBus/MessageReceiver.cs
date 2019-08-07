using System;
using System.Threading.Tasks;
using Common.Client;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;

namespace Common.ServiceBus
{
    public class MessageReceiver : IMessageReceiver, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IClientFactory _factory;
        
        private IQueueClient Client => _factory?.Create(); 

        public MessageReceiver(IClientFactory factory, ILogger<MessageReceiver> logger)
        {
            _factory = factory;
            _logger = logger;
        }

        public async Task CloseAsync()
        {
            _logger.LogDebug($"CloseAsync called for {nameof(MessageReceiver)}");

            if(Client != null && !Client.IsClosedOrClosing)
                await Client.CloseAsync();
        }

        public void Dispose()
        {
            CloseAsync().GetAwaiter().GetResult();
        }
    }
}
