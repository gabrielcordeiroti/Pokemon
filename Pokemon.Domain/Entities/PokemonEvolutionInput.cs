namespace Pokemon.Domain.Entities
{
    public class PokemonEvolutionInput
    {
        //não tive tempo de implementar as evoluções, infelizmente tive problemas pessoais.
        //basicamente faria o mesmo processo feito na chamada dos pokemons, somente com a diferença que teria que pegar a 
        //url(https://pokeapi.co/api/v2/pokemon-species/{idPokemon}/) no objeto PokemonInput, faria uma requisição passando o id do pokemon
        //depois teria que fazer outra requisição em outra url(https://pokeapi.co/api/v2/evolution-chain/1/), e por fim faria o AutoMapper
        //pra classe PokemonEvolution e preencheria o atributo da classe Pokemom, retornaria somente os nomes deles*
    }
}
