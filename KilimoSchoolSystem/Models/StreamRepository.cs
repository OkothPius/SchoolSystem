using KilimoSchoolSystem.Data;

namespace KilimoSchoolSystem.Models
{
    public class StreamRepository: IStreamRepository
    {
        private readonly KilimoSchoolSystemContext _kilimoSchoolSystemContext;

        public StreamRepository(KilimoSchoolSystemContext kilimoSchoolSystemContext)
        {
            _kilimoSchoolSystemContext = kilimoSchoolSystemContext;
        }

        public IEnumerable<Stream> AllStreams
        {
            get
            {

            }
        }
    }
}
