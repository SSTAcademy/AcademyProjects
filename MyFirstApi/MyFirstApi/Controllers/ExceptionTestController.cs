using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Filter;
using Newtonsoft.Json;

namespace MyFirstApi.Controllers;

[Route("api/[controller]")]
public class ExceptionTestController:ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ExceptionTestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("config-test")]
        public string ConfigTest()
        {
            var secretKey = _configuration.GetValue<string>("Secrets:SecretKey");
            var accessKey = _configuration.GetValue<int>("Secrets:AccessKey");
            var count = _configuration.GetValue<int>("Secrets:Props:Count");
            var copyrightOwner = _configuration.GetValue<string>("Copyright:Owner");
            return "OK";
        }
        [HttpGet]
        [Route("filter-test")]
        [TestActionFilter]
        public ActionResult FilterTest()
        {
            try
            {
                var response = new TestActionFilter.Response
                {
                    Message = "dilara"
                };
                return new ContentResult
                {
                    Content = JsonConvert.SerializeObject(response),
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }

