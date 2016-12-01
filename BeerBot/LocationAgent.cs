using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BeerBot.Models;
using Newtonsoft.Json;
using BeerBot.Models.Bing;
using System.Net.Http;

namespace BeerBot
{
    public class LocationAgent
    {

     
        private static LocationAgent instance;

        public static LocationAgent Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocationAgent();
                }
                return instance;
            }
        }


        public static string CognativeSubscriptionKey = "746d516093f64b22bf47f3d680375413";
        public static string BingMapsSubscriptionKey = "AsSaTo7cTNdz0rfFTSDWbse_8cgBiXEErjjPXMOjAvHNvG1IUxLeHTvaJTFSp2BH";

        public static string RootUrl = "https://api.cognitive.microsoft.com/bing/v5.0/knowledge/";

        public async Task<Models.Untapped.LocalModel.Venue> GetVenue(string venueName, string city)
        {
            List<Models.Untapped.LocalModel.Venue> VenueList = new List<Models.Untapped.LocalModel.Venue>();
            

            if ((venueName != null && city != null))
            {
                

        var res = await GetData($"{RootUrl}?q={venueName} {city}&setmkt=en-gb&DetectEntities=true&Subscription-Key={CognativeSubscriptionKey}");
                var root = JsonConvert.DeserializeObject<Models.Bing.Rootobject>(res);
                string urlBingMaps = "http://dev.virtualearth.net/REST/v1/Locations";

                foreach (var place in root.places.value)
                {

                    var resPlaces = await GetData($"{urlBingMaps}?postalCode={place.address.postalCode}&addressLine={ place.address.streetAddress}&includeNeighborhood=Yes&maxResults=3&key={BingMapsSubscriptionKey}");
                    var rootPlaces = JsonConvert.DeserializeObject<Models.BingMaps.Rootobject>(resPlaces);

                    foreach (var bingMapsResourceSet in rootPlaces.resourceSets)
                    {
                        foreach (var bingMapsResource in bingMapsResourceSet.resources)
                        {

                            float lat = (bingMapsResource.bbox[0] + (bingMapsResource.bbox[2] - bingMapsResource.bbox[0]) / 2);
                            float lng = (bingMapsResource.bbox[1] + (bingMapsResource.bbox[3] - bingMapsResource.bbox[1]) / 2);


                            var venue = await BeerAgent.Instance.GetLocals(lat, lng);
                            return venue;

                        }
                    }


                }
            }
            return null;

        }


        public async Task<string> GetData(string request)
        {
            var http = new HttpClient();
            var res = await http.GetAsync(request);
            return await res.Content.ReadAsStringAsync();
        }

    }



 


}

