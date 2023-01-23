using MailApi.Linq;

namespace MailApi.Services
{
    public interface IService
    {
        void Send(string message,string recipient);
    }
}
