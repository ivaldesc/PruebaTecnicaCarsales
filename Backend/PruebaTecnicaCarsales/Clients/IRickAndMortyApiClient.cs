using PruebaTecnicaCarsales.Models;

namespace PruebaTecnicaCarsales.Clients
{
    public interface IRickAndMortyApiClient
    {
        Task<EpisodeResponse> GetEpisodeAsyncAll(int page);
        Task<EpisodeDetails> GetEpisodeAsyncById(int id);
    }
}
