using System.Threading.Tasks;

namespace Tweetiment.Service.Rest
{
    public interface IApiClient
    {
        Task<string> GetAsync(string path);
        void PostAsync();
        void PutAsync();
        void DeleteAsync();
    }
}
