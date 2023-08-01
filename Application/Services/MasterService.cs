using Application.DTOs.Master;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Base.Exceptions;
using Domain.Entities;

namespace Application.Services;

public class MasterService : IMasterService
{
    private readonly IMasterRepository _masterRepository;
    private readonly IPokemonService _pokemonService;
    private readonly IMapper _mapper;

    public MasterService(IMasterRepository masterRepository, IMapper mapper, IPokemonService pokemonService)
    {
        _masterRepository = masterRepository;
        _mapper = mapper;
        _pokemonService = pokemonService;
    }

    public async Task<MasterDto> CreateMasterAsync(CreateMasterDto createMasterDto)
    {
        var entity = _mapper.Map<Master>(createMasterDto);
        
        bool isEmailAlreadyRegistered = await _masterRepository.EmailAlreadyRegisteredAsync(entity.Email);
        if (isEmailAlreadyRegistered) throw new Exception("Email already registered");
        
        bool isDocumentAlreadyRegistered = await _masterRepository.DocumentAlreadyRegisteredAsync(entity.Document);
        if (isDocumentAlreadyRegistered) throw new Exception("Document already registered");
        
        await _masterRepository.InsertAsync(entity);

        await _masterRepository.CommitAsync();
        
        return _mapper.Map<MasterDto>(entity);
    }

    public async Task<MasterDto> UpdateMasterAsync(UpdateMasterDto updateMasterDto)
    {
        var entity = await _masterRepository.GetByIdAsync(updateMasterDto.Id);
        if (entity == null) throw new AppException("Master not found");

        if(string.IsNullOrEmpty(updateMasterDto.Email) == false)
        {
            var isEmailAlreadyRegistered =
                await _masterRepository.EmailAlreadyRegisteredAsync(updateMasterDto.Email, entity.Id);

            if (isEmailAlreadyRegistered) throw new AppException("Email already registered");
            
            entity.SetEmail(updateMasterDto.Email);
        }
        
        if(string.IsNullOrEmpty(updateMasterDto.Document) == false)
        {
            var isDocumentAlreadyRegistered =
                await _masterRepository.DocumentAlreadyRegisteredAsync(updateMasterDto.Document, entity.Id);

            if (isDocumentAlreadyRegistered) throw new AppException("Document already registered");
            
            entity.SetDocument(updateMasterDto.Document);
        }

        if (string.IsNullOrEmpty(updateMasterDto.Name) == false) entity.SetName(updateMasterDto.Name);
        
        _masterRepository.Update(entity);

        await _masterRepository.CommitAsync();
        
        return _mapper.Map<MasterDto>(entity);
    }

    public async Task<bool> CapturePokemonAsync(CapturePokemonDto capturePokemonDto)
    {
        var master = await _masterRepository.GetByIdAsync(capturePokemonDto.MasterId);
        if (master == null) throw new AppException("Master not found");

        var pokemonDto = await _pokemonService.GetPokemonAsync(capturePokemonDto.PokemonId);
        if (pokemonDto == null) throw new AppException("Pokemon not found");
        
        var pokemon = _mapper.Map<Pokemon>(pokemonDto);
        
        master.CapturePokemon(pokemon);
        
        _masterRepository.Update(master);
        
        return _masterRepository.CommitAsync().IsCompletedSuccessfully;
    }

    public async Task<List<MasterDto>> GetAllMastersAsync() 
        => _mapper.Map<List<MasterDto>>(await _masterRepository.GetAllAsync());
}