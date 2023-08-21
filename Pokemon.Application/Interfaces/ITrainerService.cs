using Pokemon.Domain.Entities;

namespace Pokemon.Application.Interfaces
{
    public interface ITrainerService
    {
        Task<int> AddTrainerAsync(PokeTrainer trainerInput);
        Task<List<PokeTrainer>> GetAllTrainersAsync();
        Task<PokeTrainer> GetTrainerByIdAsync(int id);
        Task<int> UpdateTrainerAsync(PokeTrainer updatedTrainer);
        Task<bool> DeleteTrainerAsync(int id);
        Task<bool> CapturePokemonAsync(int trainerId, int pokemonId);
        Task<List<PokemonCaught>> GetCapturedPokemonsByTrainerIdAsync(int trainerId);
    }
}
