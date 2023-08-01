using Application.DTOs.Master;
using Application.DTOs.Pokemon;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class PokemonMappingProfile: Profile
{
    public PokemonMappingProfile()
    {
        CreateMap<PokemonDto, Pokemon>().ReverseMap();
    }
}