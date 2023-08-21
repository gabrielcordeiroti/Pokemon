using System.ComponentModel.DataAnnotations;

namespace Pokemon.Domain.Entities
{
    public class PokemonCaught : BaseEntity
    {
        public PokemonCaught(int idPokemon,int idTrainer, DateTime dateCaught)
        {
            IdPokemon = idPokemon;
            IdTrainer = idTrainer;
            DateCaught = dateCaught;
        }

        public int IdPokemon { get; set; }
        public int IdTrainer { get; set; }
        public DateTime DateCaught { get; set; }
    }
}
