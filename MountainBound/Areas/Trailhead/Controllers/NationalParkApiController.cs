using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MountainBound.Areas.Trailhead.Models;
using Newtonsoft.Json.Linq;


//used to seed database only should have
//admin authorization

//call to /Trailhead/NationalParks/index will seed DB with Nat park data; 
//"unknown" is added to values where no lat and long data is avail; will need to remove from DB, query: delete from NationalParks where NationalParks.Lat='unknown';

namespace MountainBound.Areas.Trailhead.Controllers
{
    [Area("Trailhead")]
    public class NationalParkApiController : Controller
    {
        private INationalParkApiRepository _repository;

        public NationalParkApiController(INationalParkApiRepository repository)
        {
            _repository = repository;
        }

        //call to api for national park data
        public async Task Index()
        {
            using (HttpClient client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("https://developer.nps.gov/");
                var response =
                    await client.GetAsync(
                        $"api/v1/parks?limit=88&q=national%20park&fields=Addresses%2Cimages&sort=fullName&api_key=hBmsOHpo5rbqEnPrPYpvhhTqd3ExLRgdfUQv0DJj");
                response.EnsureSuccessStatusCode();
                var stringresult = await response.Content.ReadAsStringAsync();
                JObject convert = JObject.Parse(stringresult);
                List<JToken> results = convert["data"].Children().ToList();
                List<NationalPark> natParks = new List<NationalPark>();
                //digging out and breaking up string that holds lat and long data
                foreach (JToken result in results)
                {
                    var lat = "";
                    var lon = "";
                    var latlong = result["latLong"].ToString().Split(", ");
                    if (latlong[0].Length > 4 && latlong[1].Length > 5)
                    {
                        lat = latlong[0]?.Substring(4);
                        lon = latlong[1]?.Substring(5);
                    }
                    else
                    {
                        lat = "unknown";
                        lon = "unknown";
                    }

                    var nationalPark = new NationalPark()
                    {
                        FullName = (string) result["fullName"],
                        Lat = lat,
                        Lon = lon,
                        City = (string) result["addresses"][0]["city"],
                        State = (string) result["addresses"][0]["stateCode"],
                        ImageAltText = (string) result["images"][0]["altText"],
                        ImageTitle = (string) result["images"][0]["title"],
                        ImageCaption = (string) result["images"][0]["caption"],
                        ImageUrl = (string) result["images"][0]["url"]
                    };
                    natParks.Add(nationalPark);
                }

                _repository.AddMultipleParks(natParks);


            }


        }
    }
}



            


