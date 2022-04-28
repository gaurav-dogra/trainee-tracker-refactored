using Trainee_Tracker.Domain.Models;

namespace Trainee_Tracker.Domain.Interfaces;
public interface ICourseRepository : IRepositoryBase<Course>
{
    IEnumerable<string> GetAllCoursesNames();
    Task<IEnumerable<Course>> GetAllCoursesAsync();
    Task<Course?> GetCourseByIdAsync(int courseId);
    Task<Course?> GetCourseByName(string courseName);
    void CreateCourse(Course course);
    void UpdateCourse(Course course);
    void RemoveCourse(Course course);
}
