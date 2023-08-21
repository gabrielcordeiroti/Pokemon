using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokemon.Domain.Entities;

namespace Pokemon.Data.Configuration
{
    public class PokemonCaughtConfigurations : IEntityTypeConfiguration<PokemonCaught>
    {
        public void Configure(EntityTypeBuilder<PokemonCaught> builder)
        {
            builder
                .HasKey(s => s.Id);
        }
    }
}
