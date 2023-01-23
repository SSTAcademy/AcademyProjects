using MailApi.Linq;
using MediatR;

namespace MailApi.MailMediator.GetMail
{
    public class GetMailQuery : IRequest<Email>
    {
        public int Number { get; set; }
    } 
}
