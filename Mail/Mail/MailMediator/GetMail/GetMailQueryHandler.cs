using MailApi.Linq;
using MediatR;

namespace MailApi.MailMediator.GetMail
{
    public class GetMailQueryHandler : IRequestHandler<GetMailQuery, Email>
    {
        public Task<Email> Handle(GetMailQuery request, CancellationToken cancellationToken)
        {
            Database db = new Database();
            db.EmailList.Distinct();
            var mail = db.EmailList.FirstOrDefault(f => f.Number == request.Number);
            return Task.FromResult(mail);
        }
    }
}
