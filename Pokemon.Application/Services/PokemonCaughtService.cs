using Pokemon.Application.Interfaces;
using Pokemon.Domain.Entities;
using Pokemon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.Services
{
    public class PokemonCaughtService : IPokemonCaughtService
    {
        private readonly IPokemonCaughtRepository _pokemonCaughtRepository;
        public PokemonCaughtService(IPokemonCaughtRepository pokemonCaughtRepository)
        {
            _pokemonCaughtRepository = pokemonCaughtRepository;
        }
        public async Task<int> AddAsync(PokemonCaught pokemon)
        {
            if (pokemon == null)
            {
                throw new ArgumentNullException(nameof(pokemon));
            }

            return await _pokemonCaughtRepository.AddAsync(pokemon);
        }
        public async Task<PokemonCaught> GetPokemonCaughtByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Pokemon ID must be greater than 0.");
            }

            return await _pokemonCaughtRepository.GetPokemonCaughtByIdAsync(id);
        }
    }
}
