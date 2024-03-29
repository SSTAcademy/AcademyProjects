﻿using Newtonsoft.Json;

namespace MyFirstApi.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _requestDelegate;

        public GlobalExceptionHandler(RequestDelegate requestDelegate)//middleware'lerde kesin olması gereken yapı =request inject=
        {
            _requestDelegate= requestDelegate;
        }

        public async Task InvokeTaskAsync(HttpContext httpContext)//middleware'lerde kesin olması gereken yapı =invokeasync=
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task HandleException(HttpContext httpContext, Exception e)
        {
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new Error
            {
                StatusCodes = httpContext.Response.StatusCode,
                Message = e.Message
            }));
        }
        public class Error
        {
            public int StatusCodes { get; set; }
            public string Message { get; set; }

        }
    }

   
}
