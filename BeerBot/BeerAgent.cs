using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using BeerBot.Models;
using Newtonsoft.Json;

namespace BeerBot
{
    public class BeerAgent
    {
        public static string ClientId = "C9C3218FC4970A807B5FFD053149384EE40E36B4";
        public static string ClientSecret = "F9A0F02556AA03BEA76725B8A5639E9EEE2D622E";
        public static string AuthQueryString = $"client_id={ClientId}&client_secret={ClientSecret}";
        public static string RootUrl = "https://api.untappd.com/v4/";

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
            var res = await GetData($"{RootUrl}thepub/local?{AuthQueryString}&lat={lat}&lng={lon}");
            var root = JsonConvert.DeserializeObject<Rootobject>(res);
            var beers = root.response.checkins.items.Select(i => i.beer);
            return beers;
        }

        public async Task<string> GetData(string request)
        {
            var http = new HttpClient();
            var res = await http.GetAsync(request);
            return await res.Content.ReadAsStringAsync();
        }
    }
}