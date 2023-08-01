namespace Application.DTOs.Master;

public class UpdateMasterDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Email { get; set; }
    public string? Document { get; set; }
}