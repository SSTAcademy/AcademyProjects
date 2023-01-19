using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using EmailApi.Filter;
using EmailApi.Linq;
using EmailApi.StudentMediator.CreateMail;
using EmailApi.StudentMediator.GetMail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmailApi.Controllers
{
    [Route("api/[controller]")]
    public class MailController : Controller
    {
        private readonly IMediator _mediator;

            public MailController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet]
        [Route("{number}")]
        [CheckFilter]
        public async Task<JsonResult> GetMail(int number)
        {
            var query = new GetMailQuery
            {
                Number = number
            };
            var mail = await _mediator.Send(query);
            return new JsonResult(mail);

        }
        [HttpGet]
        [Route("mail")]
        public async Task<JsonResult> GetMail()
        {
            Database db = new Database();
            var mails = new List<Email>();
            mails = mails.Distinct().ToList();
            return new JsonResult(mails);

        }

        [HttpPost]
            public async Task<JsonResult> CreateStudent(CreateMailCommand command)
            {
                var result = await _mediator.Send(command);


                return new JsonResult(result);
            }

            [HttpGet]
            [Route("filter-test/{emailAdress}")]

            [CheckFilter]
            public IActionResult FilterTest(string emailAdress)
            {
                return Empty;//yapamadım

            }
        

    }
    }

