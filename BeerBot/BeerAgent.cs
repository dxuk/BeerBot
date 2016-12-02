using System;
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

        private IEnumerable<BeerBot.Models.Untapped.VenueModel.TopBeer> BeerList { get; set; }


        /// <summary>
        /// Get a list of the types of beer served at the pub local to lat long
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetLocalsBeerTypes(int venueID)
        {
            var localsBeers = await GetLocalsBeerList(venueID);
            var styles = localsBeers.Select(b => b.beer.beer_style).Distinct();
            return styles;
        }

        /// <summary>
        /// Get a list of beers served at the pub local to lat and long
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <returns></returns>
        public async Task<IEnumerable<BeerBot.Models.Untapped.VenueModel.TopBeer>> GetLocalsBeerList(int venueID)
        {
            if (BeerList == null)
            {
                var res = await GetData($"{RootUrl}/venue/info/{venueID}?{AuthQueryString}");
                var root = JsonConvert.DeserializeObject<Models.Untapped.VenueModel.Rootobject>(res);
                BeerList = root.response.venue.top_beers.items.Where(b => b.beer.beer_active == 1  );
            }
            return BeerList;
        }

        public async Task<Models.Untapped.LocalModel.Venue> GetLocals(double lat, double lon)
        {
            
                var res = await GetData($"{RootUrl}thepub/local?{AuthQueryString}&lat={lat}&lng={lon}");
                var root = JsonConvert.DeserializeObject<Models.Untapped.LocalModel.Rootobject>(res);
           
           
            return root.response.checkins.items.OrderBy(i => i.distance).Select(i => i.venue).First();
        }

        internal void ClearBeerCache()
        {
            BeerList = null;
        }

        public async Task<string> GetData(string request)
        {
            var http = new HttpClient();
            var res = await http.GetAsync(request);
            return await res.Content.ReadAsStringAsync();
        }

        public async Task<IEnumerable<string>> GetBeersByType(string type, int venueID)
        {
            var localsBeers = await GetLocalsBeerList(venueID);
            return localsBeers.Where(b => b.beer.beer_style == type).Select(b => b.beer.beer_name);
        }
    }
}