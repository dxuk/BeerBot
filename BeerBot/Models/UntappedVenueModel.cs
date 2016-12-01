using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerBot.Models.Untapped.VenueModel
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
        public Venue venue { get; set; }
    }
    [Serializable]
    public class Venue
    {
        public int venue_id { get; set; }
        public string venue_name { get; set; }
        public string venue_slug { get; set; }
        public string last_updated { get; set; }
        public string primary_category { get; set; }
        public Categories categories { get; set; }
        public Stats stats { get; set; }
        public Venue_Icon venue_icon { get; set; }
        public bool public_venue { get; set; }
        public Location location { get; set; }
        public Contact contact { get; set; }
        public Foursquare foursquare { get; set; }
        public Media media { get; set; }
        public Checkins checkins { get; set; }
        public Top_Beers top_beers { get; set; }
        public bool is_verified { get; set; }
    }

    public class Categories
    {
        public int count { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        public string category_name { get; set; }
        public string category_id { get; set; }
        public bool is_primary { get; set; }
    }

    public class Stats
    {
        public int total_count { get; set; }
        public int user_count { get; set; }
        public int total_user_count { get; set; }
        public int monthly_count { get; set; }
        public int weekly_count { get; set; }
    }

    public class Venue_Icon
    {
        public string sm { get; set; }
        public string md { get; set; }
        public string lg { get; set; }
    }

    public class Location
    {
        public string venue_address { get; set; }
        public string venue_city { get; set; }
        public string venue_state { get; set; }
        public string venue_country { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Contact
    {
        public string twitter { get; set; }
        public string venue_url { get; set; }
        public string facebook { get; set; }
    }

    public class Foursquare
    {
        public string foursquare_id { get; set; }
        public string foursquare_url { get; set; }
    }

    public class Media
    {
        public int count { get; set; }
        public Item1[] items { get; set; }
    }

    public class Item1
    {
        public int photo_id { get; set; }
        public Photo photo { get; set; }
        public string created_at { get; set; }
        public int checkin_id { get; set; }
        public Beer beer { get; set; }
        public Brewery brewery { get; set; }
        public User user { get; set; }
        public Venue1 venue { get; set; }
    }

    public class Photo
    {
        public string photo_img_sm { get; set; }
        public string photo_img_md { get; set; }
        public string photo_img_lg { get; set; }
        public string photo_img_og { get; set; }
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
        public Contact1 contact { get; set; }
        public Location1 location { get; set; }
        public int brewery_active { get; set; }
    }

    public class Contact1
    {
        public string twitter { get; set; }
        public string facebook { get; set; }
        public string url { get; set; }
    }

    public class Location1
    {
        public string brewery_city { get; set; }
        public string brewery_state { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class User
    {
        public int uid { get; set; }
        public string user_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_avatar { get; set; }
        public string relationship { get; set; }
        public int is_private { get; set; }
    }

    public class Venue1
    {
        public int venue_id { get; set; }
        public string venue_name { get; set; }
        public string venue_slug { get; set; }
        public string primary_category { get; set; }
        public string parent_category_id { get; set; }
        public Categories1 categories { get; set; }
        public Location2 location { get; set; }
        public Contact2 contact { get; set; }
        public bool public_venue { get; set; }
        public Foursquare1 foursquare { get; set; }
        public Venue_Icon1 venue_icon { get; set; }
        public bool is_verified { get; set; }
    }

    public class Categories1
    {
        public int count { get; set; }
        public Item2[] items { get; set; }
    }

    public class Item2
    {
        public string category_name { get; set; }
        public string category_id { get; set; }
        public bool is_primary { get; set; }
    }

    public class Location2
    {
        public string venue_address { get; set; }
        public string venue_city { get; set; }
        public string venue_state { get; set; }
        public string venue_country { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Contact2
    {
        public string twitter { get; set; }
        public string venue_url { get; set; }
    }

    public class Foursquare1
    {
        public string foursquare_id { get; set; }
        public string foursquare_url { get; set; }
    }

    public class Venue_Icon1
    {
        public string sm { get; set; }
        public string md { get; set; }
        public string lg { get; set; }
    }

    public class Checkins
    {
        public int count { get; set; }
        public Item3[] items { get; set; }
    }

    public class Item3
    {
        public int checkin_id { get; set; }
        public string created_at { get; set; }
        public float rating_score { get; set; }
        public string checkin_comment { get; set; }
        public User1 user { get; set; }
        public Beer1 beer { get; set; }
        public Brewery1 brewery { get; set; }
        public Venue2 venue { get; set; }
        public Comments comments { get; set; }
        public Toasts toasts { get; set; }
        public Media1 media { get; set; }
        public Source source { get; set; }
        public Badges badges { get; set; }
    }

    public class User1
    {
        public int uid { get; set; }
        public string user_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public object relationship { get; set; }
        public int is_supporter { get; set; }
        public string user_avatar { get; set; }
        public int is_private { get; set; }
    }

    public class Beer1
    {
        public int bid { get; set; }
        public string beer_name { get; set; }
        public float beer_abv { get; set; }
        public string beer_label { get; set; }
        public string beer_slug { get; set; }
        public string beer_style { get; set; }
        public int auth_rating { get; set; }
        public bool wish_list { get; set; }
        public int beer_active { get; set; }
    }

    public class Brewery1
    {
        public int brewery_id { get; set; }
        public string brewery_name { get; set; }
        public string brewery_slug { get; set; }
        public string brewery_label { get; set; }
        public string country_name { get; set; }
        public Contact3 contact { get; set; }
        public Location3 location { get; set; }
        public int brewery_active { get; set; }
    }

    public class Contact3
    {
        public string twitter { get; set; }
        public string facebook { get; set; }
        public string instagram { get; set; }
        public string url { get; set; }
    }

    public class Location3
    {
        public string brewery_city { get; set; }
        public string brewery_state { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Venue2
    {
        public int venue_id { get; set; }
        public string venue_name { get; set; }
        public string venue_slug { get; set; }
        public string primary_category { get; set; }
        public string parent_category_id { get; set; }
        public Categories2 categories { get; set; }
        public Location4 location { get; set; }
        public Contact4 contact { get; set; }
        public bool public_venue { get; set; }
        public Foursquare2 foursquare { get; set; }
        public Venue_Icon2 venue_icon { get; set; }
        public bool is_verified { get; set; }
    }

    public class Categories2
    {
        public int count { get; set; }
        public Item4[] items { get; set; }
    }

    public class Item4
    {
        public string category_name { get; set; }
        public string category_id { get; set; }
        public bool is_primary { get; set; }
    }

    public class Location4
    {
        public string venue_address { get; set; }
        public string venue_city { get; set; }
        public string venue_state { get; set; }
        public string venue_country { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Contact4
    {
        public string twitter { get; set; }
        public string venue_url { get; set; }
    }

    public class Foursquare2
    {
        public string foursquare_id { get; set; }
        public string foursquare_url { get; set; }
    }

    public class Venue_Icon2
    {
        public string sm { get; set; }
        public string md { get; set; }
        public string lg { get; set; }
    }

    public class Comments
    {
        public int total_count { get; set; }
        public int count { get; set; }
        public Item5[] items { get; set; }
    }

    public class Item5
    {
        public User2 user { get; set; }
        public int checkin_id { get; set; }
        public int comment_id { get; set; }
        public bool comment_owner { get; set; }
        public bool comment_editor { get; set; }
        public string comment { get; set; }
        public string created_at { get; set; }
        public string comment_source { get; set; }
    }

    public class User2
    {
        public int uid { get; set; }
        public string user_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string bio { get; set; }
        public string location { get; set; }
        public string relationship { get; set; }
        public int is_supporter { get; set; }
        public string user_avatar { get; set; }
        public string account_type { get; set; }
        public object[] venue_details { get; set; }
        public object[] brewery_details { get; set; }
        public string user_link { get; set; }
    }

    public class Toasts
    {
        public int total_count { get; set; }
        public int count { get; set; }
        public object auth_toast { get; set; }
        public Item6[] items { get; set; }
    }

    public class Item6
    {
        public int uid { get; set; }
        public User3 user { get; set; }
        public int like_id { get; set; }
        public bool like_owner { get; set; }
        public string created_at { get; set; }
    }

    public class User3
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
        public object[] brewery_details { get; set; }
        public string user_link { get; set; }
    }

    public class Media1
    {
        public int count { get; set; }
        public Item7[] items { get; set; }
    }

    public class Item7
    {
        public int photo_id { get; set; }
        public Photo1 photo { get; set; }
    }

    public class Photo1
    {
        public string photo_img_sm { get; set; }
        public string photo_img_md { get; set; }
        public string photo_img_lg { get; set; }
        public string photo_img_og { get; set; }
    }

    public class Source
    {
        public string app_name { get; set; }
        public string app_website { get; set; }
    }

    public class Badges
    {
        public int count { get; set; }
        public Item8[] items { get; set; }
    }

    public class Item8
    {
        public int badge_id { get; set; }
        public int user_badge_id { get; set; }
        public string badge_name { get; set; }
        public string badge_description { get; set; }
        public string created_at { get; set; }
        public Badge_Image badge_image { get; set; }
    }

    public class Badge_Image
    {
        public string sm { get; set; }
        public string md { get; set; }
        public string lg { get; set; }
    }

    public class Top_Beers
    {
        public int offset { get; set; }
        public int limit { get; set; }
        public int count { get; set; }
        public TopBeer[] items { get; set; }
    }

    public class TopBeer
    {
        public string created_at { get; set; }
        public int total_count { get; set; }
        public int your_count { get; set; }
        public Beer2 beer { get; set; }
        public Brewery2 brewery { get; set; }
        public Friends friends { get; set; }
    }

    public class Beer2
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
        public float rating_score { get; set; }
        public int rating_count { get; set; }
    }

    public class Brewery2
    {
        public int brewery_id { get; set; }
        public string brewery_name { get; set; }
        public string brewery_slug { get; set; }
        public string brewery_label { get; set; }
        public string country_name { get; set; }
        public Contact5 contact { get; set; }
        public Location5 location { get; set; }
        public int brewery_active { get; set; }
    }

    public class Contact5
    {
        public string twitter { get; set; }
        public string facebook { get; set; }
        public string url { get; set; }
    }

    public class Location5
    {
        public string brewery_city { get; set; }
        public string brewery_state { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Friends
    {
        public object[] items { get; set; }
        public int count { get; set; }
    }


}