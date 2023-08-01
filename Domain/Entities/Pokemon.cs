using Base.Entities;

namespace Domain.Entities;

public class Pokemon: Entity
{
    public int BaseExperience { get; set; }
    public int Height { get; set; }
    public bool IsDefault { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    public int Weight { get; set; }
    public Master Master { get; set; }
    public int MasterId { get; set; }
}