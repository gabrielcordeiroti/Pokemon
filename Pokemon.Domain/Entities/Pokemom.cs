namespace Pokemon.Domain.Entities
{
    public class Pokemom : BaseEntity
    {
        public Pokemom(string name, int height, int weight)
        {
            Name = name;
            Height = height;
            Weight = weight;

            Abilities = new List<string>();
            SpriteBase64 = new List<string>();
            Evolutions = new List<PokemonEvolution>();
        }

        public string Name { get; set; }
        public List<string> Abilities { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<PokemonEvolution> Evolutions { get; set; }
        public List<string> SpriteBase64 { get; set; }
    }
}
