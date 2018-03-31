using System.Collections.Generic;
using System.Linq;

namespace MountainBound.Areas.Trailhead.Models
{
    public class TrailMemoryRepository: ITrailRepository
    {
        private List<Trail> _trails = new List<Trail>();

        public IEnumerable<Trail> Trails { get; set; }

        public List<Trail> AddTrails(List<Trail> apiTrails)
        {
            _trails.Clear();
            _trails.AddRange(apiTrails);
            return _trails;
        }

        public Trail GetTrail(int id)
        {
            var trailDetails = _trails.FirstOrDefault(t => t.Id == id);
            return trailDetails;
        }
    }
}
