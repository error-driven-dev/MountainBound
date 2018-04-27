using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MountainBound.Areas.Trailhead.Models;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MountainBound.Areas.Trailhead.Controllers
{
    [Area("Trailhead")]
    public class TrailController : Controller
    {
        private ITrailRepository _repository;
        private INationalParkApiRepository _nationalParkRepository;

        public TrailController(ITrailRepository repository, INationalParkApiRepository natpark)
        {
            _repository = repository;
            _nationalParkRepository = natpark;
        }
        public IActionResult NationalParks()
        {

            return View(_nationalParkRepository.NationalParks.OrderBy(x => x.State));
        }


        //takes lat and lon from national park DB table
        public async Task<IActionResult> Trails(string lon, string lat, string name)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.hikingproject.com");
                var response =
                    await client.GetAsync(
                        $"/data/get-trails?lat={lat}&lon={lon}&maxDistance=200&sort=distance&maxResults=100&key=200238177-24a146be40fa02014108db565b54b2ed");
                response.EnsureSuccessStatusCode();
                var stringresult = await response.Content.ReadAsStringAsync();
                JObject result = JObject.Parse(stringresult);
                //only need if you want to get a subsection of data
                IList<JToken> rawTrailsList = result["trails"].Children().ToList();
                List<Trail> trails = new List<Trail>();
                foreach (JToken item in rawTrailsList)
                {
                    Trail singleTrail = item.ToObject<Trail>();
                    trails.Add(singleTrail);
                }

                //save to memory repository
                _repository.AddTrails(trails);
                ViewBag.NationalPark = name;
                return View(trails);
            }
        }

        public IActionResult ShowTrail(int id)
        {
            //use previous api results stored in memory to render details of individual trails -- later can add fallback to ping api with trail id
            var trail = _repository.GetTrail(id);
            if (trail == null)
            {
                return RedirectToAction("GetFromApi", new {id});
            }

            return View(trail);
        }

        //TRAIL SEARCH USING CALL TO API -- to use as fallback
        public async Task<IActionResult> GetFromApi(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://www.hikingproject.com");
                    var response =
                        await client.GetAsync(
                            $"/data/get-trails-by-id?ids={id}&key=200238177-24a146be40fa02014108db565b54b2ed");
                    response.EnsureSuccessStatusCode();
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var result = JObject.Parse(stringResult);
                    if ((bool) result["success"])
                    {
                        return RedirectToAction("Trails");
                    }

                    var trail = result["trails"][0].ToObject<Trail>();
                    return View("ShowTrail", trail);
                }
            }
 
            catch (Exception err)
            {
                
                return View("ApiError");
            }

        }

        public IActionResult Geo()
        {
            return View();
        }
    }
}
