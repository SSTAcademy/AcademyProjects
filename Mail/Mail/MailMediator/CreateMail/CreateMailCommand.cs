using MailApi.Linq;
using MediatR;

namespace MailApi.MailMediator.CreateMail
{
    public class CreateMailCommand : IRequest<Email>
    {
        public string EmailAdress { get; set; }
    }
}
