using Application.DTOs.Pokemon;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet(Name = "Get10RandomPokemon")]
    public async Task<IEnumerable<PokemonDto>> Get10RandomPokemon()
    {
        return await _pokemonService.Get10RandomPokemonListAsync();
    }
    
    [HttpGet("{pokemonId}", Name = "GetPokemon")]
    public async Task<PokemonDto> GetPokemon(int pokemonId)
    {
        return await _pokemonService.GetPokemonAsync(pokemonId);
    }
}