using System.ComponentModel.DataAnnotations;

namespace Trainee_Tracker.Domain.Models;

public class Image
{
    public int ImageId { get; set; }
    
    [Required]
    public string ImageTitle { get; set; }

    [Required]
    public byte[] ImageData { get; set; }

    public int PersonId { get; set; }
}
