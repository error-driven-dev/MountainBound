using System.Collections.Generic;
using System.Linq;
using MountainBound.Models;

namespace MountainBound.Areas.Trailhead.Models
{
    public interface INationalParkApiRepository
    {
        IQueryable<NationalPark> NationalParks { get; }
        
        void AddPark(NationalPark park);
        void AddMultipleParks(List<NationalPark> parks);
}

    public class NationalParkRepository:INationalParkApiRepository
    {
        private List<NationalPark> _nationalParks;

        private AppDbContext _context;
        public NationalParkRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<NationalPark> NationalParks => _context.NationalParks;

        public void AddPark(NationalPark park)
        {
            _context.NationalParks.Add(park);
            _context.SaveChanges();
        }

        public void AddMultipleParks(List<NationalPark> parks)
        {
            _context.NationalParks.AddRange(parks);
            _context.SaveChanges();
        }
    }
}
