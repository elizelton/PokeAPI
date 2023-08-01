using Application.DTOs.Master;

namespace Application.Interfaces.Services;

public interface IMasterService
{
    Task<MasterDto> CreateMasterAsync(CreateMasterDto createMasterDto);
    Task<MasterDto> UpdateMasterAsync(UpdateMasterDto updateMasterDto);
    Task<bool> CapturePokemonAsync(CapturePokemonDto capturePokemonDto);
    Task<List<MasterDto>> GetAllMastersAsync();
}