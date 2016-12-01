using System;

namespace BeerBot.Models.Untapped.LocalModel
{
    public class Rootobject
    {
        public Meta meta { get; set; }
        public object[] notifications { get; set; }
        public Response response { get; set; }
    }

    public class Meta
    {
        public int code { get; set; }
        public Response_Time response_time { get; set; }
        public Init_Time init_time { get; set; }
    }

    public class Response_Time
    {
        public float time { get; set; }
        public string measure { get; set; }
    }

    public class Init_Time
    {
        public float time { get; set; }
        public string measure { get; set; }
    }

    public class Response
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public string type { get; set; }
        public Pagination pagination { get; set; }
        public int radius { get; set; }
        public string dist_pref { get; set; }
        public Checkins checkins { get; set; }
    }

    public class Pagination
    {
        public string next_url { get; set; }
        public int max_id { get; set; }
        public string since_url { get; set; }
    }

    public class Checkins
    {
        public int count { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        public int checkin_id { get; set; }
        public float distance { get; set; }
        public string created_at { get; set; }
        public float rating_score { get; set; }
        public string checkin_comment { get; set; }
        public User user { get; set; }
        public Beer beer { get; set; }
        public Brewery brewery { get; set; }
        public Venue venue { get; set; }
        public Comments comments { get; set; }
        public Toasts toasts { get; set; }
        public Media media { get; set; }
    }

    public class User
    {
        public int uid { get; set; }
        public string user_name { get; set; }
        public string user_avatar { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int is_private { get; set; }
        public string location { get; set; }
        public string bio { get; set; }
        public string website { get; set; }
        public int is_supporter { get; set; }
        public object relationship { get; set; }
        public object contact { get; set; }
    }

    public class Beer
    {
        public int bid { get; set; }
        public string beer_name { get; set; }
        public string beer_label { get; set; }
        public float beer_abv { get; set; }
        public int beer_ibu { get; set; }
        public string beer_slug { get; set; }
        public string beer_description { get; set; }
        public int is_in_production { get; set; }
        public int beer_style_id { get; set; }
        public string beer_style { get; set; }
        public int auth_rating { get; set; }
        public bool wish_list { get; set; }
        public int beer_active { get; set; }
    }

    public class Brewery
    {
        public int brewery_id { get; set; }
        public string brewery_name { get; set; }
        public string brewery_slug { get; set; }
        public string brewery_label { get; set; }
        public string country_name { get; set; }
        public Contact contact { get; set; }
        public Location location { get; set; }
        public int brewery_active { get; set; }
    }

    public class Contact
    {
        public string twitter { get; set; }
        public string facebook { get; set; }
        public string url { get; set; }
    }

    public class Location
    {
        public string brewery_city { get; set; }
        public string brewery_state { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
    }
    
    [Serializable]
    public class Venue
    {
        public int venue_id { get; set; }
        public string venue_name { get; set; }
        public string venue_slug { get; set; }
        public string primary_category { get; set; }
        public string parent_category_id { get; set; }
        public Categories categories { get; set; }
        public Location1 location { get; set; }
        public Contact1 contact { get; set; }
        public bool public_venue { get; set; }
        public Foursquare foursquare { get; set; }
        public Venue_Icon venue_icon { get; set; }
        public bool is_verified { get; set; }
    }

    public class Categories
    {
        public int count { get; set; }
        public Item1[] items { get; set; }
    }

    public class Item1
    {
        public string category_name { get; set; }
        public string category_id { get; set; }
        public bool is_primary { get; set; }
    }

    public class Location1
    {
        public string venue_address { get; set; }
        public string venue_city { get; set; }
        public string venue_state { get; set; }
        public string venue_country { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Contact1
    {
        public string twitter { get; set; }
        public string venue_url { get; set; }
    }

    public class Foursquare
    {
        public string foursquare_id { get; set; }
        public string foursquare_url { get; set; }
    }

    public class Venue_Icon
    {
        public string sm { get; set; }
        public string md { get; set; }
        public string lg { get; set; }
    }

    public class Comments
    {
        public int total_count { get; set; }
        public int count { get; set; }
        public object[] items { get; set; }
    }

    public class Toasts
    {
        public int total_count { get; set; }
        public int count { get; set; }
        public object auth_toast { get; set; }
        public Item2[] items { get; set; }
    }

    public class Item2
    {
        public int uid { get; set; }
        public User1 user { get; set; }
        public int like_id { get; set; }
        public bool like_owner { get; set; }
        public string created_at { get; set; }
    }

    public class User1
    {
        public int uid { get; set; }
        public string user_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string bio { get; set; }
        public string location { get; set; }
        public string user_avatar { get; set; }
        public string account_type { get; set; }
        public object[] venue_details { get; set; }
        public object brewery_details { get; set; }
        public string user_link { get; set; }
    }

    public class Media
    {
        public int count { get; set; }
        public Item3[] items { get; set; }
    }

    public class Item3
    {
        public int photo_id { get; set; }
        public Photo photo { get; set; }
    }

    public class Photo
    {
        public string photo_img_sm { get; set; }
        public string photo_img_md { get; set; }
        public string photo_img_lg { get; set; }
        public string photo_img_og { get; set; }
    }
}