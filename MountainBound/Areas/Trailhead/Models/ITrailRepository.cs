using System.Collections.Generic;

namespace MountainBound.Areas.Trailhead.Models
{
    public interface ITrailRepository
    {
        IEnumerable<Trail> Trails { get; set; }

        List<Trail> AddTrails(List<Trail> trailList);
        Trail GetTrail(int id);

    }
}