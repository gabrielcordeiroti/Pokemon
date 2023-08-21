using Pokemon.Domain.Entities;

namespace Pokemon.Domain.Interfaces
{
    public interface IPokemonRepository
    {
        Task<PokemonInput> GetByIdAsync(string id);
        Task<List<PokemonInput>> GetRandomPokemonsAsync(int count);
    }
}
