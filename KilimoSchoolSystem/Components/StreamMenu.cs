using KilimoSchoolSystem.Models;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;

namespace KilimoSchoolSystem.Components
{
    public class StreamMenu: ViewComponent
    {
        private readonly IStreamRepository _streamRepository;

        public StreamMenu(IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public IViewComponentResult Invoke()
        {
            var streams = _streamRepository.AllStreams.OrderBy(c => c.StreamName);
            return View(streams);
        }
    }
}
