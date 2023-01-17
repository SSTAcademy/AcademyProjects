using Newtonsoft.Json;

namespace EmailApi.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _request;//middleware'lerde kesin olması gereken yapı =request inject=

        public GlobalExceptionHandler(RequestDelegate request)
        {
            _request = request;
        }
        public async Task InvokeAsync(HttpContext httpContext)//middleware'lerde kesin olması gereken yapı =invokeasync=
        {
            try
            {
                if (httpContext.Request.Body != null)
                {
                    await _request(httpContext);

                }
                
            }
            catch (Exception e)
            {
                await HandleOurException(httpContext, e);
            }
        }
        private async Task HandleOurException(HttpContext context, Exception exception)//exceptipon mesajını alıp düzenleyen metot
        {
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new Error
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }));
        }

        public class Error
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
        }
    }
}
