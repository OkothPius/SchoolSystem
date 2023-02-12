using System.IO.Pipelines;

namespace KilimoSchoolSystem.Models
{
    public class Stream
    {
        public int StreamId { get; set; }
        public string? StreamName { get; set; }
        public List<Student>? Students { get; set; }
    }
}
