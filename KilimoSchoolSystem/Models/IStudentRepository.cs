namespace KilimoSchoolSystem.Models
{
    public interface IStudentRepository
    {
        IEnumerable<Student> AllStudents { get; }
       // Student GetStudentById(int id);
    }
}
