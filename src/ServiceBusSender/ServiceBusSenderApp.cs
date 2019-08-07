using System;
using Microsoft.Extensions.Logging;
using ServiceBusSender.ServiceBus;

namespace ServiceBusSender
{
    public class ServiceBusSenderApp
    {
        private readonly ILogger _logger;
        private readonly IMessageSender _sender;

        public ServiceBusSenderApp(ILogger<ServiceBusSenderApp> logger, IMessageSender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        public void Run()
        {
            _logger.LogInformation($"Run console application {nameof(ServiceBusSenderApp)}");

            _logger.LogInformation("End Run");

            Console.ReadKey();
        }
    }
}
