using EmailApi.Linq;
using MediatR;

namespace EmailApi.StudentMediator.CreateMail
{
    public class CreateMailCommandHandler : IRequestHandler<CreateMailCommand, Email>
    {
        public Task<Email> Handle(CreateMailCommand request, CancellationToken cancellationToken)
        {
            Database db = new Database();

            var maxNumber = db.EmailList.MaxBy(m => m.Number)!.Number;
            var newNumber = maxNumber + 1;

            var newMail= new Email
            {
                Number = newNumber,
            };


            db.EmailList.Add(newMail);
            return Task.FromResult<Email>(newMail);
        }
    }
}
