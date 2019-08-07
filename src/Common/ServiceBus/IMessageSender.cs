using System.Threading.Tasks;

namespace Common.ServiceBus
{
    public interface IMessageSender
    {
        Task SendMessageAsync(string messageBody);
        Task CloseAsync();
    }
}
