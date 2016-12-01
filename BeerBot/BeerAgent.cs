using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BeerBot.Models;
using Newtonsoft.Json;

namespace BeerBot
{
    public class BeerAgent
    {
        private static BeerAgent instance;

        public static BeerAgent Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BeerAgent();
                }
                return instance;
            }
        }

        public static string ClientId = "C9C3218FC4970A807B5FFD053149384EE40E36B4";
        public static string ClientSecret = "F9A0F02556AA03BEA76725B8A5639E9EEE2D622E";
        public static string AuthQueryString = $"client_id={ClientId}&client_secret={ClientSecret}";
        public static string RootUrl = "https://api.untappd.com/v4/";

        private IEnumerable<Beer> BeerList { get; set; }

        /// <summary>
        /// Get a list of the types of beer served at the pub local to lat long
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetLocalsBeerTypes(double lat, double lon)
        {
            var localsBeers = await GetLocalsBeerList(lat, lon);
            var styles = localsBeers.Select(b => b.beer_style).Distinct();
            return styles;
        }

        /// <summary>
        /// Get a list of beers served at the pub local to lat and long
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Beer>> GetLocalsBeerList(double lat, double lon)
        {
            if (BeerList == null)
            {
                var res = await GetData($"{RootUrl}thepub/local?{AuthQueryString}&lat={lat}&lng={lon}");
                var root = JsonConvert.DeserializeObject<Rootobject>(res);
                BeerList = root.response.checkins.items.Select(i => i.beer).Take(5);
            }
            return BeerList;
        }

        public async Task<string> GetData(string request)
        {
            var http = new HttpClient();
            var res = await http.GetAsync(request);
            return await res.Content.ReadAsStringAsync();
        }

        public async Task<IEnumerable<string>> GetBeersByType(string type, double lat, double lon)
        {
            var localsBeers = await GetLocalsBeerList(lat, lon);
            return localsBeers.Where(b => b.beer_style == type).Select(b => b.beer_name);
        }
    }
}