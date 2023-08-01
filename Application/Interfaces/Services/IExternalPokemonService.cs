using Application.DTOs;
using Application.DTOs.Pokemon;
using Refit;

namespace Application.Interfaces.Services;

public interface IExternalPokemonService
{
    [Get("/pokemon/{id}")]
    Task<PokemonDto> GetPokemon([AliasAs("id")] int pokemonId);
}