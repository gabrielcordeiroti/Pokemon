using Pokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.Interfaces
{
    public interface IPokemonCaughtService
    {
        Task<int> AddAsync(PokemonCaught pokemon);
        Task<PokemonCaught> GetPokemonCaughtByIdAsync(int id);
    }
}
