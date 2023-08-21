using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Domain.Entities;
using Pokemon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Infrastructure.Repositories
{
    public class PokemonCaughtRepository : IPokemonCaughtRepository
    {
        private readonly TrainerPokemonDbContext _dbContext;

        public PokemonCaughtRepository(TrainerPokemonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(PokemonCaught pokemon)
        {
            try
            {
                var result = await _dbContext.PokemonCaught.AddAsync(pokemon);
                await _dbContext.SaveChangesAsync();
                return result.Entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }

        public async Task<PokemonCaught> GetPokemonCaughtByIdAsync(int pokemon)
        {
            try
            {
                var result = await _dbContext.PokemonCaught.FindAsync(pokemon);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }
    }
}
