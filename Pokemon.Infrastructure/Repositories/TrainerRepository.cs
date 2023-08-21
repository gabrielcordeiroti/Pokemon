using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Domain.Entities;
using Pokemon.Domain.Interfaces;

namespace Pokemon.Infrastructure.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly TrainerPokemonDbContext _dbContext;

        public TrainerRepository(TrainerPokemonDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(PokeTrainer trainer)
        {
            try
            {
                var result = await _dbContext.Trainers.AddAsync(trainer);
                await _dbContext.SaveChangesAsync();
                return result.Entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }

        public async Task<bool> CapturePokemonAsync(int trainerId, int pokemonId)
        {
            var trainer = await _dbContext.Trainers.FindAsync(trainerId);

            if (trainer == null)
                return false;

            var pokemonCaught = new PokemonCaught(pokemonId, trainerId, DateTime.Now);

            trainer.PokemonCaughts.Add(pokemonCaught);

            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<List<PokemonCaught>> GetCapturedPokemonsByTrainerIdAsync(int trainerId)
        {
            var trainer = await _dbContext.Trainers
                .Include(t => t.PokemonCaughts)
                .FirstOrDefaultAsync(t => t.Id == trainerId);

            return trainer?.PokemonCaughts ?? new List<PokemonCaught>();
        }

        public async Task<bool> DeleteTrainerPokemonAsync(int id)
        {
            try
            {
                var trainer = await _dbContext.Trainers.Where(x => x.Id == id).FirstOrDefaultAsync();
                _dbContext.Entry(trainer).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }

        public async Task<List<PokeTrainer>> GetAllTrainersAsync()
        {
            try
            {
                var result = await _dbContext.Trainers.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }

        public async Task<PokeTrainer> GetByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Trainers.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }

        public async Task<int> UpdateTrainerPokemonAsync(PokeTrainer trainer)
        {
            try
            {
                _dbContext.Entry(trainer).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return trainer.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }
    }
}
