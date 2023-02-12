namespace KilimoSchoolSystem.Models
{
    public interface IStreamRepository
    {
        IEnumerable<Stream> AllStreams { get; }
    }
}
 