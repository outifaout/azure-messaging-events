using Microsoft.Azure.ServiceBus;

namespace ServiceBusSender.ServiceBus
{
    public interface IClientFactory
    {
        IQueueClient Create();
        IQueueClient Create(MessageSenderSettings settings);
    }
}
