using Newtonsoft.Json;
using Pokemon.Domain.Entities;
using Pokemon.Domain.Interfaces;
using Pokemon.Infrastructure.Configuration;

namespace Pokemon.Infrastructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ExternalApiConfiguration _externalApiConfiguration;

        public PokemonRepository(IHttpClientFactory httpClientFactory, ExternalApiConfiguration externalApiConfig)
        {
            _httpClientFactory = httpClientFactory;
            _externalApiConfiguration = externalApiConfig;
        }

        public async Task<PokemonInput> GetByIdAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync($"{_externalApiConfiguration.ExternalApiBaseUrl}/pokemon/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var pokemon = JsonConvert.DeserializeObject<PokemonInput>(content);
                return pokemon;
            }

            return null;
        }

        public async Task<List<PokemonInput>> GetRandomPokemonsAsync(int count)
        {
            var client = _httpClientFactory.CreateClient();

            var randomPokemons = new List<PokemonInput>();

            for (int i = 0; i < count; i++)
            {
                var randomId = new Random().Next(1, 151); // IDs dos Pokémons só da primeira geração rsrs
                var response = await client.GetAsync($"{_externalApiConfiguration.ExternalApiBaseUrl}/pokemon/{randomId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var pokemon = JsonConvert.DeserializeObject<PokemonInput>(content);
                    randomPokemons.Add(pokemon);
                }
            }

            return randomPokemons;
        }
    }
}
