using MyFirstApi.Attributes;
using Newtonsoft.Json;

namespace MyFirstApi.Linq
{
    public class Student
    {
        [Help("https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/attributes")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Rank { get; set; }
        public int Number { get; set; }
    }
}
