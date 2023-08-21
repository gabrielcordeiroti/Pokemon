using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pokemon.Domain.Entities;

namespace Pokemon.Data.Configuration
{
    public class TrainerConfigurations : IEntityTypeConfiguration<PokeTrainer>
    {
        public void Configure(EntityTypeBuilder<PokeTrainer> builder)
        {
            builder
                .HasKey(trainer => trainer.Id);

            builder
                .Property(trainer => trainer.Name)
                .IsRequired();

            builder
                .Property(trainer => trainer.Age)
                .IsRequired();

            builder
                .Property(trainer => trainer.CPF)
                .IsRequired();

            builder
            .HasMany(trainer => trainer.PokemonCaughts)
            .WithOne()
            .HasForeignKey(trainer => trainer.IdTrainer)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
