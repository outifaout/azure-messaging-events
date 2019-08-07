using Microsoft.Azure.ServiceBus;

namespace Common.ServiceBus
{
    public interface IClientFactory
    {
        IQueueClient Create();
        IQueueClient Create(MessageSenderSettings settings);
    }
}
