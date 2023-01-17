using EmailApi.Linq;
using EmailApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmailApi.Controllers
{
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        [HttpGet]
        [Route("email/{number}")]
        public JsonResult GetStudent(int number)//tek mail
        {
            Database db = new Database();
            var mail = db.EmailList.FirstOrDefault(f => f.Number == number);
            var response = new ResponseModel
            {
                StatusCode = 200,
                Message = "Success",
                Data = mail
            };
            return new JsonResult(response);
        }

        [HttpGet]
        [Route("email")]//tüm mailler
        public JsonResult GetStudents()
        {
            Database db = new Database();
            var response = new ResponseModel
            {
                StatusCode = 200,
                Message = "Success",
                Data = db.EmailList
            };
            return new JsonResult(response);
        }
        [HttpDelete]
        [Route("email/{number}")]
        public JsonResult DeleteMail(int number)
        {
            Database db = new Database();
            var mail = db.EmailList.FirstOrDefault(f => f.Number == number);
            if (mail == null)
            {
                var errorResponse = new ResponseModel
                {
                    StatusCode = 404,
                    Message = "Not Found",
                    Data = null
                };
                return new JsonResult(errorResponse);
            }

            db.EmailList.Remove(mail);

            var response = new ResponseModel
            {
                StatusCode = 200,
                Message = "Success",
                Data = db.EmailList
            };
            return new JsonResult(response);
        }
    }
}
