using Application.DTOs.Master;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class MasterMappingProfile: Profile
{
    public MasterMappingProfile()
    {
        CreateMap<CreateMasterDto, Master>()
            .ConstructUsing(x => new Master(x.Name, x.BirthDate, x.Email, x.Document));
        
        CreateMap<Master, MasterDto>();
    }
}