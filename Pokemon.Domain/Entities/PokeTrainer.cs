using System.ComponentModel.DataAnnotations;

namespace Pokemon.Domain.Entities
{
    public class PokeTrainer : BaseEntity
    {
        public PokeTrainer(string name, int age, string cPF)
        {
            Name = name;
            Age = age;
            CPF = cPF;
        }

        [Required(ErrorMessage = "Nome Obrigatório")]
        [MaxLength(150)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Idade Obrigatório")]
        public int Age { get; set; }

        [Required(ErrorMessage = "CPF Obrigatório")]
        [MaxLength(11)]
        public string CPF { get; set; }
        public int? IdPokemons { get; set; }
        public List<PokemonCaught>? PokemonCaughts { get; set; }
    }
}

