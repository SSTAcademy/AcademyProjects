using EmailApi.Linq;
using MediatR;

namespace EmailApi.StudentMediator.GetMail
{
    public class GetMailQueryHandler : IRequestHandler<GetMailQuery, Email>
    {
        public Task<Email> Handle(GetMailQuery request, CancellationToken cancellationToken)
        {
            Database db = new Database();
            var mail = db.EmailList.FirstOrDefault(f => f.Number == request.Number);
            return Task.FromResult(mail);
        }
    }
}
