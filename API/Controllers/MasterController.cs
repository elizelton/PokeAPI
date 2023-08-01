using Application.DTOs.Master;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
public class MasterController: ControllerBase
{
    private readonly IMasterService _masterService;

    public MasterController(IMasterService masterService)
    {
        _masterService = masterService;
    }
    
    [HttpPost(Name = "CreatePokemonMaster")]
    public async Task<IActionResult> CreatePokemonMaster([FromBody] CreateMasterDto createMasterDto)
    {
        return CreatedAtRoute("CreatePokemonMaster", await _masterService.CreateMasterAsync(createMasterDto));
    }
    
    [HttpPut("{id}", Name = "UpdatePokemonMaster")]
    public async Task<IActionResult> UpdatePokemonMaster(int id, [FromBody] UpdateMasterDto updateMasterDto)
    {
        updateMasterDto.Id = id;
        return Ok(await _masterService.UpdateMasterAsync(updateMasterDto));
    }
    
    [HttpPost("/capture", Name = "CapturePokemon")]
    public async Task<IActionResult> CapturePokemon([FromBody] CapturePokemonDto capturePokemonDto)
    {
        return Ok(await _masterService.CapturePokemonAsync(capturePokemonDto));
    }
    
    [HttpGet(Name = "GetAllMasters")]
    public async Task<IActionResult> GetAllMasters()
    {
        return Ok(await _masterService.GetAllMastersAsync());
    }
}