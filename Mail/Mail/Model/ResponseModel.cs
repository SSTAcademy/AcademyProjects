﻿namespace MailApi.Model
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
