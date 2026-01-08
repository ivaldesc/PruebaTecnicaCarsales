using PruebaTecnicaCarsales.Models;
using System.Net.Http;
using System.Text.Json;

namespace PruebaTecnicaCarsales.Common
{
    public class Utils
    {
        public async Task<T> GetAsync<T>(string url, HttpClient client)
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var episodios = JsonSerializer.Deserialize<T>(json);

            return episodios;
        }
    }
}
