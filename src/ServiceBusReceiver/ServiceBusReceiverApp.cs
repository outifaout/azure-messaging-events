using System;
using System.Threading.Tasks;
using Common.ServiceBus;
using Microsoft.Extensions.Logging;

namespace ServiceBusReceiver
{
    internal class ServiceBusReceiverApp
    {
        private readonly ILogger _logger;
        private readonly IMessageReceiver _receiver;

        public ServiceBusReceiverApp(IMessageReceiver messageReceiver, ILogger<ServiceBusReceiverApp> logger)
        {
            _receiver = messageReceiver;
            _logger = logger;
        }
        public async Task RunAsync()
        {
            _logger.LogInformation($"BEGIN - {nameof(ServiceBusReceiverApp)} starting");

            _receiver.ReceiveMessages();

            Console.ReadKey();

            await _receiver.CloseAsync();

            _logger.LogInformation($"END - {nameof(ServiceBusReceiverApp)} finished");
        }

    }
}
