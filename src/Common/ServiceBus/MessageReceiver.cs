using System;
using System.Text;
using System.Threading;
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

        public void ReceiveMessages()
        {
            var messageHandlerOptions = 
                new MessageHandlerOptions(ExceptionReceivedHandler)
                {
                    MaxConcurrentCalls = 1,
                    AutoComplete = false
                };

            Client.RegisterMessageHandler(
                ProcessMessageHandlerAsync,
                messageHandlerOptions);
        }

        private async Task ProcessMessageHandlerAsync(Message message, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Received message: SequenceNumber: {message.SystemProperties.SequenceNumber}, Body: {Encoding.UTF8.GetString(message.Body)}");
            await Client.CompleteAsync(message.SystemProperties.LockToken);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceived)
        {
            var context = exceptionReceived.ExceptionReceivedContext;
            _logger.LogError(exceptionReceived.Exception, $"Exception occurred - Endpoint: {context.Endpoint}, EntityPath: {context.EntityPath}, Action: {context.Action}");
            return Task.CompletedTask;
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
