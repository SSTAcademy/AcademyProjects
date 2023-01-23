using MailApi.Services;

namespace MailApi.Linq
{
    public class Email:IService
    {
        public int Number { get; set; }
        public string EmailAdress { get; set; }
       
        public void Send(string message, string recipient)
        {
            Console.WriteLine(recipient+" alıcısına "+ message +" adlı mailiniz gönderildi.");
        }


    }
}
