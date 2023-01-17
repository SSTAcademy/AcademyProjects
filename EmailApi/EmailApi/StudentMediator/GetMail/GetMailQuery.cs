using EmailApi.Linq;
using MediatR;

namespace EmailApi.StudentMediator.GetMail
{
    public class GetMailQuery : IRequest<Email>
    {
        public int Number { get; set; }
    }
}
