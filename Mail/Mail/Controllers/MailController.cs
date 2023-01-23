using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using MailApi.Filter;
using MailApi.Linq;
using MailApi.MailMediator.GetMail;
using MailApi.MailMediator.CreateMail;
using MailApi.MailMediator.GetAllMail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MailApi.Controllers
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
        public async Task<List<Email>> GetAllMail()
        {
            //var mail = await _mediator.Send(new GetAllMailQuery());
            return await _mediator.Send(new GetAllMailQuery());

            //return Ok(result);
             //return new JsonResult(result);

        }

        [HttpPost]
        public async Task<JsonResult> CreateStudent([FromBody] CreateMailCommand command)
        {
            var result = await _mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("filter-test/{emailAdress}")]

        [CheckFilter]
        public IActionResult FilterTest(string emailAdress)
        {
            try
            {
              return new ContentResult
                {
                    Content = JsonConvert.SerializeObject(emailAdress)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


    }
}

