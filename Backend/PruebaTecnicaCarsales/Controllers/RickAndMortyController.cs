using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaCarsales.Clients;
using PruebaTecnicaCarsales.Models;

namespace PruebaTecnicaCarsales.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RickAndMortyController :ControllerBase
    {
        public readonly IRickAndMortyApiClient _rickAndMortyApiClient;

        public RickAndMortyController(IRickAndMortyApiClient rickAndMortyApiClient)
        {
            _rickAndMortyApiClient = rickAndMortyApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1)
        {
            var result = await _rickAndMortyApiClient.GetEpisodeAsyncAll(page);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _rickAndMortyApiClient.GetEpisodeAsyncById(id);
            return Ok(result);
        }
    }
}
