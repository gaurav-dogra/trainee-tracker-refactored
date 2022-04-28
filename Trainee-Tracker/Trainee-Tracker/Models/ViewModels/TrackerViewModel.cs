using System.ComponentModel.DataAnnotations;
using Trainee_Tracker.Domain.Models;

namespace Trainee_Tracker.Models.ViewModels
{
    public class TrackerViewModel
    {
        [Key]
        public int TrackerId { get; set; }

        [Range(1, 52)]
        [Required]
        public int WeekNumber { get; set; }

        public string? StartDoing { get; set; } = string.Empty;
        public string? StopDoing { get; set; } = string.Empty;
        public string? ContinueDoing { get; set; } = string.Empty;
        public SkillLevelEnums? TechSkills { get; set; }
        public SkillLevelEnums? ConsultancySkills { get; set; }
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public string? SearchString { get; set; }
    }
}
