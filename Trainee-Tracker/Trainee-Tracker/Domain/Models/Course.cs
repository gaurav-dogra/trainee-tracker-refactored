using System.ComponentModel.DataAnnotations;
using Trainee_Tracker.Domain.Interfaces;

namespace Trainee_Tracker.Domain.Models;

public class Course : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public List<Trainee> Trainees { get; set; } = new();

    public List<Trainer> Trainers { get; set; } = new();
}
