using MailApi.Linq;
using MediatR;

namespace MailApi.MailMediator.GetAllMail
{
    public class GetAllMailQuery : IRequest<List<Email>>
    {
       
    }
}
