using System.Threading.Tasks;

namespace Common.ServiceBus
{
    public interface IMessageReceiver
    {
        Task CloseAsync();
    }
}
