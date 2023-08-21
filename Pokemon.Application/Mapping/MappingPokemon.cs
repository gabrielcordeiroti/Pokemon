using AutoMapper;
using Pokemon.Domain.Entities;

namespace Pokemon.Application.Mapping
{
    public class MappingPokemon : Profile
    {
        public MappingPokemon()
        {
            CreateMap<PokemonInput, Pokemom>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Abilities, opt => opt.MapFrom(src => src.Abilities.Select(a => a.AbilityAbility.Name).ToList()))
               .ForMember(dest => dest.Height, opt => opt.MapFrom(src => (int)src.Height))
               .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => (int)src.Weight))
               .ForMember(dest => dest.SpriteBase64, opt => opt.MapFrom(src => new List<string> { src.Sprites.FrontDefault.ToString(), src.Sprites.BackDefault.ToString() }));
        }

    }
}
