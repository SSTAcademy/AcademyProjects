using Microsoft.AspNetCore.Identity;

namespace EmailApi.Linq
{
    public class Database
    {
        public Database()
        {
            EmailList = new List<Email>()
            {
                new()
                {
                    Number= 1,
                    EmailAdress = "dilara@gmail.com"
                },
                new()
                {   Number=2,
                    EmailAdress = "ali@gmail.com"
            }, new()
                {   Number=3,
                    EmailAdress = "ayse@gmail.com"
                }
            };
        }
        public List<Email> EmailList { get; set; }
    }
}
