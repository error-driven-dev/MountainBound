using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MountainBound.Areas.Trailhead.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MountainBound.Areas.Trailhead.Controllers
{
    [Area("Trailhead")]
    public class DirectoryController : Controller
    {
        private INationalParkApiRepository _nationalParkRepository;

        public DirectoryController(INationalParkApiRepository nationalParkRepository)
        {
            _nationalParkRepository = nationalParkRepository;
        }

        public IActionResult NationalParks()
        {
            
            return View(_nationalParkRepository.NationalParks.OrderBy(x=>x.State));
        }
    }
}
