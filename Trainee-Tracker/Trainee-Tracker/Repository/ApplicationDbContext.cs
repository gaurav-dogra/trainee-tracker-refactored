using Microsoft.EntityFrameworkCore;
using Trainee_Tracker.Domain.Models;

namespace Trainee_Tracker.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
    {

    }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Image> Images { get; set; }
    public virtual DbSet<Tracker> Trackers { get; set; }
}
