using System.ComponentModel.DataAnnotations;
using Trainee_Tracker.Domain.Interfaces;
using Trainee_Tracker.Models;

namespace Trainee_Tracker.Domain.Models;

public class Trainer : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    // Is there an data validation I can use here
    public Image? ProfileImage { get; set; }
    [Required]
    public int CourseId { get; set; }
    public Course CurrentCourse { get; set; }


}
