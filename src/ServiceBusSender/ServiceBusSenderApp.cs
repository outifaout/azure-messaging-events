using System;
using System.Threading.Tasks;
using Common.ServiceBus;
using Microsoft.Extensions.Logging;

namespace ServiceBusSender
{
    internal class ServiceBusSenderApp
    {
        private readonly ILogger _logger;
        private readonly IMessageSender _sender;

        public ServiceBusSenderApp(IMessageSender sender, ILogger<ServiceBusSenderApp> logger)
        {
            _logger = logger;
            _sender = sender;
        }

        public async Task RunAsync()
        {
            _logger.LogInformation($"BEGIN - {nameof(ServiceBusSenderApp)} starting");

            await SendMessages(_sender, 10);
             
            // Console.ReadKey();

            await _sender.CloseAsync();

            _logger.LogInformation($"END - {nameof(ServiceBusSenderApp)} finished");
        }

        public async Task SendMessages(IMessageSender messageSender, int numberOfMessagesToSend)
        {
            try
            {
                _logger.LogInformation($"attempting to send {numberOfMessagesToSend} messages to the queue");
                for (var i = 0; i < numberOfMessagesToSend; i++)
                {
                    await messageSender.SendMessageAsync($"Message {i}");
                }
                _logger.LogInformation($"{numberOfMessagesToSend} messages sent to queue");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error attempting to send messages to queue");
            }
        }
    }
}
