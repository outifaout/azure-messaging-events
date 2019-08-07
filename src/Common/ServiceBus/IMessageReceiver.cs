using System.Threading.Tasks;

namespace Common.ServiceBus
{
    public interface IMessageReceiver
    {
        void ReceiveMessages();
        Task CloseAsync();
    }
}
