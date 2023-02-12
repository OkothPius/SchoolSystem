using KilimoSchoolSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace KilimoSchoolSystem.Models
{
    public class StudentRepository: IStudentRepository
    {
        private readonly KilimoSchoolSystemContext _kilimoSchoolSystemContext;

        public StudentRepository(KilimoSchoolSystemContext kilimoSchoolSystemContext)
        {
            _kilimoSchoolSystemContext = kilimoSchoolSystemContext;
        }

        // Adding Interfaces
        public IEnumerable<Student> AllStudents 
        {
            get
            {
                return _kilimoSchoolSystemContext.Student.Include(c => c.Stream);
            }
        }
    }
}
