using System.ComponentModel.DataAnnotations;

namespace KilimoSchoolSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(30)]
        public string AdmissionNumber { get; set; } = string.Empty;

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public int StreamId { get; set; }
        public Stream? Stream { get; set; }
    }
}
