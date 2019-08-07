using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ServiceBusSender.ServiceBus
{
    public class QueueClientFactory : IClientFactory
    {
        private readonly ILogger _logger;
        private readonly MessageSenderSettings _settings;

        public QueueClientFactory(IOptions<MessageSenderSettings> settings, ILogger<QueueClientFactory> logger)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        public IQueueClient Create()
        {
            return Create(_settings);
        }

        public IQueueClient Create(MessageSenderSettings settings)
        {
            _logger.LogDebug($"Create new IQueueClient for queue {settings.QueueName} in namespace {settings.ServiceBusNamespace}");
            return new QueueClient(settings.GetConnectionString(), settings.QueueName);
        }
    }
}
