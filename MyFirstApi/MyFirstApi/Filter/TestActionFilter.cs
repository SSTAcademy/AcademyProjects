using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyFirstApi.Filter
{
    public class TestActionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string varIpAdress = string.Empty;
            var testValue = context.HttpContext.Request.Headers["Test"];

            Console.WriteLine(testValue);
            if (testValue == "123456")
            {
                context.Result = new UnauthorizedResult();
                base.OnActionExecuting(context);
            }
            
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.Result = new ContentResult()
            {
                Content = "test"
            };

            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
        }

        public class Response
        {
            public string Message { get; set; }
        }
    }
}
