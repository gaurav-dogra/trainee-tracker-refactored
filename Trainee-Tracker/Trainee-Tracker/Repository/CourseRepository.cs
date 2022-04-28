using Microsoft.EntityFrameworkCore;
using Trainee_Tracker.Domain.Interfaces;
using Trainee_Tracker.Domain.Models;
using Trainee_Tracker.Models;

namespace Trainee_Tracker.Repository;
public class CourseRepository : RepositoryBase<Course>, ICourseRepository
{
    public CourseRepository(ApplicationDbContext context) : base(context)
    {
    }
    public IEnumerable<string> GetAllCoursesNames()
    {
        return GetAll()
            .Select(course => course.Name)
            .ToList();
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        return await GetAll()
            .ToListAsync();
    }

    public async Task<Course?> GetCourseByIdAsync(int courseId)
    {
        return await GetByCondition(course => course.Id == courseId)
            .FirstOrDefaultAsync();
    }

    public async Task<Course?> GetCourseByName(string courseName)
    {
        return await GetByCondition(course => course.Name == courseName)
            .FirstOrDefaultAsync();
    }

    public void CreateCourse(Course course)
    {
        Add(course);
    }

    public void UpdateCourse(Course course)
    {
        Update(course);
    }

    public void RemoveCourse(Course course)
    {
        Remove(course);
    }
}
