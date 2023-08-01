using Application.DTOs;
using Application.DTOs.Pokemon;

namespace Application.Interfaces.Services;

public interface IPokemonService
{
    Task<List<PokemonDto>> Get10RandomPokemonListAsync();
    
    Task<PokemonDto> GetPokemonAsync(int pokemonId);
}