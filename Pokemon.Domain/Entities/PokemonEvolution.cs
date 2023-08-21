namespace Pokemon.Domain.Entities
{
    public class PokemonEvolution : BaseEntity
    {
        public PokemonEvolution(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
