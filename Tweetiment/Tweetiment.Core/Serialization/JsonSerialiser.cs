using System.Text.Json;
using System.Threading.Tasks;

namespace Tweetiment.Core.Serialization
{
    public class JsonSerialiser : IHttpSerialiser
    {
        public TData Deserialise<TData>(string source)
        {
            return JsonSerializer.Deserialize<TData>(source);
        }

        public string Serialise<TData>(TData target)
        {
            return JsonSerializer.Serialize<TData>(target);
        }
    }
}
