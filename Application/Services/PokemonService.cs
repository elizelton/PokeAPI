using Application.DTOs;
using Application.DTOs.Pokemon;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;

namespace Application.Services;

public class PokemonService : IPokemonService
{
    private readonly IExternalPokemonService _externalPokemonService;
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IMapper _mapper;

    public PokemonService(IExternalPokemonService externalPokemonService, IPokemonRepository pokemonRepository, IMapper mapper)
    {
        _externalPokemonService = externalPokemonService;
        _pokemonRepository = pokemonRepository;
        _mapper = mapper;
    }

    public async Task<List<PokemonDto>> Get10RandomPokemonListAsync()
    {
        var randomIds = GetRandomIds(1, 1000, 10);
            
        var callsApi = randomIds.Select(GetPokemonAsync);

        var pokemons = await Task.WhenAll(callsApi);

        return pokemons.ToList();
    }

    public async Task<PokemonDto> GetPokemonAsync(int pokemonId)
    { 
        var dto = await _externalPokemonService.GetPokemon(pokemonId);
        var entity = _mapper.Map<Domain.Entities.Pokemon>(dto);
        await _pokemonRepository.UpsertAsync(entity);
        return dto;
    }

    private List<int> GetRandomIds(int minValue, int maxValue, int count)
    {
        var random = new Random();
        var uniqueNumbers = new HashSet<int>();

        while (uniqueNumbers.Count < count)
        {
            uniqueNumbers.Add(random.Next(minValue, maxValue + 1));
        }

        return uniqueNumbers.ToList();
    }

    
}