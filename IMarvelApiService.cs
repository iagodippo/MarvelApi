using System.Threading.Tasks;
using Refit;

namespace marvelApi
{
    public interface IMarvelApiService
    {
        [Get("/characters?ts={ts}&apikey={apikey}&hash={hash}&name={heroeName}")]
        Task<HeroeResponseDto> GetHeroeAsync(
            string heroeName, 
            string ts,
            string apikey,
            string hash);
    }
}