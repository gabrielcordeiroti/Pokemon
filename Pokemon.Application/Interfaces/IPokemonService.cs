using Pokemon.Domain.Entities;

namespace Pokemon.Application.Interfaces
{
    public interface IPokemonService
    {
        Task<Pokemom> GetPokemonByIdAsync(string id);
        Task<List<Pokemom>> GetRandomPokemonsAsync(int count);
    }
}
