using Microsoft.AspNetCore.Mvc.Rendering;

namespace Trainee_Tracker.Models.ViewModels
{
    public class TraineeCourseNameViewModel
    {
        //public List<TraineeRepository>? TraineeRepository { get; set; }
        public List<TraineeViewModel> Trainees { get; set; }
        public SelectList? Courses { get; set; }
        public string? TraineeCourse { get; set; }
        public string? SearchString { get; set; }
        public string? TrainerSearchString { get; set; }
    }
}
