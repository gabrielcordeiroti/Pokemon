using Pokemon.Domain.Entities;

namespace Pokemon.Domain.Interfaces
{
    public interface ITrainerRepository
    {
        Task<PokeTrainer> GetByIdAsync(int id);
        Task<int> AddAsync(PokeTrainer trainer);
        Task<List<PokeTrainer>> GetAllTrainersAsync();
        Task<int> UpdateTrainerPokemonAsync(PokeTrainer trainer);
        Task<bool> DeleteTrainerPokemonAsync(int id);
        Task<bool> CapturePokemonAsync(int trainerId, int pokemonId);
        Task<List<PokemonCaught>> GetCapturedPokemonsByTrainerIdAsync(int trainerId);
    }
}
