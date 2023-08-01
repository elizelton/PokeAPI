using Base.Dto;

namespace Application.DTOs.Master;

public class MasterDto : BaseDto
{
    public string Name { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string Email { get; set; } = null!;
    public string Document { get; set; } = null!;
}