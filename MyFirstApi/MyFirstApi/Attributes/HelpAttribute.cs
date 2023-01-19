using System.Security.Policy;
using Newtonsoft.Json;

namespace MyFirstApi.Attributes
{

    //Attribute için kısıtlar
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property)]

    //Attribute kod yazarken ulaşabileceğimiz kolaylıklar ve işlevsellikleri sağlar
    public class HelpAttribute : Attribute
    {
        public HelpAttribute(string url)//mesela konuya yardımcı link
        {
            Url = url;
        }
        public string Url { get; set; }
    }
}
