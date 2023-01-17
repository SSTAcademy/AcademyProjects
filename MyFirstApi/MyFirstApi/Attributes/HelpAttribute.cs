using System.Security.Policy;
using Newtonsoft.Json;

namespace MyFirstApi.Attributes
{
    public class HelpAttribute:Attribute
    {
        public HelpAttribute(string url)
        {
            Url = url;
        }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
