using Microsoft.EntityFrameworkCore;
using Pokemon.Domain.Entities;
using System.Reflection;

namespace Pokemon.Data
{
    public class TrainerPokemonDbContext : DbContext
    {
        public TrainerPokemonDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<PokeTrainer> Trainers { get; set; }
        public DbSet<PokemonCaught> PokemonCaught { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
