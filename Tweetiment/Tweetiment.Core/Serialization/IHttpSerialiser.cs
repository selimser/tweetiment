using System.Threading.Tasks;

namespace Tweetiment.Core.Serialization
{
    /// <summary>
    /// Helper for serialising and deserialising between objects and serialised data.
    /// </summary>
    public interface IHttpSerialiser //can be generalised if needed, doesn't have to be only for HTTP messages.
    {
        string Serialise<TData>(TData target);
        TData Deserialise<TData>(string source);
    }
}
