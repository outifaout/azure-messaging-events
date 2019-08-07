using Common.Settings;
using Microsoft.Azure.ServiceBus;

namespace Common.Client
{
    public interface IClientFactory
    {
        IQueueClient Create();
        IQueueClient Create(MessageSenderSettings settings);
    }
}
