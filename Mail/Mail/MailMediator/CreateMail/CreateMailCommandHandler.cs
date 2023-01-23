using MailApi.Linq;
using MediatR;

namespace MailApi.MailMediator.CreateMail
{
    public class CreateMailCommandHandler : IRequestHandler<CreateMailCommand, Email>
    {

        public Task<Email> Handle(CreateMailCommand request, CancellationToken cancellationToken)
        {
            Database db = new Database();

            var maxNumber = db.EmailList.MaxBy(m => m.Number)!.Number;
            var newNumber = maxNumber + 1;

            var newMail = new Email
            {
                Number = newNumber,
                EmailAdress = request.EmailAdress,
              
            };

            db.EmailList.Add(newMail);
            return Task.FromResult<Email>(newMail);
        }
    }
}
