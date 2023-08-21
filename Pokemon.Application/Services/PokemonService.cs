using AutoMapper;
using Pokemon.Application.Interfaces;
using Pokemon.Domain.Entities;
using Pokemon.Domain.Interfaces;

namespace Pokemon.Application.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IMapper _mapper;
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IMapper mapper, IPokemonRepository pokemonRepository)
        {
            _mapper = mapper;
            _pokemonRepository = pokemonRepository;
        }
        public async Task<Pokemom> GetPokemonByIdAsync(string id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);
            var pokemom = _mapper.Map<Pokemom>(pokemon);

            return pokemom;
        }

        public async Task<List<Pokemom>> GetRandomPokemonsAsync(int count)
        {
            var pokemonList = await _pokemonRepository.GetRandomPokemonsAsync(count);
            var pokemomList = _mapper.Map<List<Pokemom>>(pokemonList);

            return pokemomList;
        }
    }
}
