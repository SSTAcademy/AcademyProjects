using EmailApi.Linq;
using MediatR;

namespace EmailApi.StudentMediator.CreateMail
{
    public class CreateMailCommand : IRequest<Email>
    {
        public string EmailAdress { get; set; }
    }
}
