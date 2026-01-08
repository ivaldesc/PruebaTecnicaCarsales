using PruebaTecnicaCarsales.Common;
using PruebaTecnicaCarsales.Models;
using System.Text.Json;

namespace PruebaTecnicaCarsales.Clients
{
    public class RickAndMortyApiClient : IRickAndMortyApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly Utils _utils;

        public RickAndMortyApiClient(HttpClient httpClient, Utils utils)
        {
            _httpClient = httpClient;
            _utils = utils;
        }

        public async Task<EpisodeResponse> GetEpisodeAsyncAll(int page)
        {
            var url = $"episode?page={page}";

            var episodios = await _utils.GetAsync<EpisodeResponse>(url, _httpClient);

            return episodios;
        }

        public async Task<EpisodeDetails> GetEpisodeAsyncById(int id)
        {
            var url = $"episode/{id}";
            var episodios = await _utils.GetAsync<Episode>(url, _httpClient);

            var characterIds = episodios.characters
                .Select(c => int.Parse(c.Split('/').Last()))
                .ToList();

            var ids = string.Join(",", characterIds);

            var characters = await _utils.GetAsync<List<Character>>($"character/{ids}", _httpClient);
            //EpisodeDetails details;

            //episodios.characters = characters.Select(c => c.name).ToList();


            //return episodios;

            return new EpisodeDetails
            {
                episode = episodios,
                charactersDetails = characters
            };

        }
    }
}
