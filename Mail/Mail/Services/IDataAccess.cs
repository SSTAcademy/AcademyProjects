using MailApi.Linq;

namespace MailApi.Services
{
    public interface IDataAccess
    {
        List<Email> GetMails();
    }
}
