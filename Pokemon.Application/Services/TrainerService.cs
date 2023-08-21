using Pokemon.Application.Interfaces;
using Pokemon.Domain.Entities;
using Pokemon.Domain.Interfaces;

namespace Pokemon.Application.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IPokemonCaughtRepository _pokemonCaughtRepository;

        public TrainerService(ITrainerRepository trainerRepository, IPokemonCaughtRepository pokemonCaughtRepository)
        {
            _trainerRepository = trainerRepository;
            _pokemonCaughtRepository = pokemonCaughtRepository;
        }
        public async Task<int> AddTrainerAsync(PokeTrainer trainer)
        {
            if (trainer == null)
            {
                throw new ArgumentNullException(nameof(trainer));
            }

            return await _trainerRepository.AddAsync(trainer);
        }

        public async Task<bool> CapturePokemonAsync(int trainerId, int pokemonId)
        {
            var result = await _pokemonCaughtRepository.AddAsync(new PokemonCaught(pokemonId, trainerId, DateTime.Now));

            var captured = await _trainerRepository.CapturePokemonAsync(trainerId, result);

            if (captured)
            {
                var trainer = await _trainerRepository.GetByIdAsync(trainerId);

                if (trainer.PokemonCaughts == null)
                    trainer.PokemonCaughts = new List<PokemonCaught>();

                var pokemonCaught = new PokemonCaught(pokemonId, trainerId, DateTime.Now);
                trainer.PokemonCaughts.Add(pokemonCaught);

                await _trainerRepository.UpdateTrainerPokemonAsync(trainer);
            }

            return captured;
        }

        public async Task<bool> DeleteTrainerAsync(int id)
        {
            return await _trainerRepository.DeleteTrainerPokemonAsync(id);
        }

        public async Task<List<PokeTrainer>> GetAllTrainersAsync()
        {
            return await _trainerRepository.GetAllTrainersAsync();
        }

        public Task<List<PokemonCaught>> GetCapturedPokemonsByTrainerIdAsync(int trainerId)
        {
            return _trainerRepository.GetCapturedPokemonsByTrainerIdAsync(trainerId);
        }

        public async Task<PokeTrainer> GetTrainerByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Trainer ID must be greater than 0.");
            }

            return await _trainerRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateTrainerAsync(PokeTrainer updatedTrainer)
        {
            return await _trainerRepository.UpdateTrainerPokemonAsync(updatedTrainer);
        }
    }
}
