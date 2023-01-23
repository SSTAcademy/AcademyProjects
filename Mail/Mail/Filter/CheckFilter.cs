using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace MailApi.Filter
{ //yapamadım
    public class CheckFilter: ActionFilterAttribute
    {
        private bool IsValid(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    var result = context.ModelState;
        //    if (IsValid(result))
        //    {
        //        context.Result = new UnauthorizedResult();
        //        base.OnActionExecuting(context);
        //    }
        //    else
        //    {
        //        throw new Exception();
        //    }

        //}


        public override void OnActionExecuted(ActionExecutedContext context)
        {


        }
    }

}
