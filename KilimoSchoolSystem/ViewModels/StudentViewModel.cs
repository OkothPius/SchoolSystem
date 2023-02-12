using KilimoSchoolSystem.Models;

namespace KilimoSchoolSystem.ViewModels
{
    public class StudentViewModel
    {
        public IEnumerable<Student>? Students { get; set; }
        public string? CurrentStream { get; set; }
    }
}
