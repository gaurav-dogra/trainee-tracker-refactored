using System.ComponentModel.DataAnnotations;
using Trainee_Tracker.Domain.Interfaces;
using Trainee_Tracker.Models;

namespace Trainee_Tracker.Domain.Models;

public class Tracker : IEntity
{
    [Key]
    public int Id { get; set; }

    [Range(1, 52)]
    [Required]
    public int WeekNumber { get; set; }

    public string? StartDoing { get; set; } = string.Empty;
    public string? StopDoing { get; set; } = string.Empty;
    public string? ContinueDoing { get; set; } = string.Empty;
    public SkillLevelEnums? TechSkills { get; set; }
    public SkillLevelEnums? ConsultancySkills { get; set; }
    
    //below should be made required
    public int TraineeId { get; set; }
    public Trainee Trainee { get; set; }
}
