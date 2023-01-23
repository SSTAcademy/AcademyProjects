using MailApi.Linq;
using MailApi.Model;
using MailApi.Services;
using MediatR;
using MailApi.MailMediator.GetAllMail;

namespace MailApi.MailMediator.GetAllMail
{
    public class GetAllMailQueryHandler : IRequestHandler<GetAllMailQuery, List<Email>>
    {
        private readonly IDataAccess _data;
        public GetAllMailQueryHandler(IDataAccess data)
        {
            _data = data;
        }
    
        public async  Task<List<Email>> Handle(GetAllMailQuery request, CancellationToken cancellationToken)
        {
            var mail = new Email();
            var liste =  _data.GetMails();
            return _data.GetMails();
            
        }
    }


}
