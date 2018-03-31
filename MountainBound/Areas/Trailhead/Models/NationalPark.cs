using System;
using System.Collections.Generic;
using System.Net.Mime;
using Newtonsoft.Json.Linq;

namespace MountainBound.Areas.Trailhead.Models
{
    public class NationalPark
    {
        public int NationalParkId { get; set; }
        public string FullName { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ImageAltText { get; set; }
        public string ImageTitle { get; set; }
        public string ImageCaption { get; set; }
        public string ImageUrl { get; set; }
     
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }



}
