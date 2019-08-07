using System.Threading.Tasks;

namespace ServiceBusSender.ServiceBus
{
    public interface IMessageSender
    {
        Task SendMessageAsync(string message);
    }
}
