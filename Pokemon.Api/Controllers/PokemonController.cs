using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.Interfaces;

namespace Pokemon.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetPokemonById(string id)
        {
            var pokemon = await _pokemonService.GetPokemonByIdAsync(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }
        [HttpGet("getRandom/{count}")]
        public async Task<IActionResult> GetRandomPokemons(int count)
        {
            var pokemons = await _pokemonService.GetRandomPokemonsAsync(count);

            if (pokemons == null || pokemons.Count == 0)
            {
                return NotFound();
            }

            return Ok(pokemons);
        }
    }
}
