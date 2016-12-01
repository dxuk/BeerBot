using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerBot.Models.Bing
{
    public class Rootobject
    {
        public string _type { get; set; }
        public Instrumentation instrumentation { get; set; }
        public Querycontext queryContext { get; set; }
        public Places places { get; set; }
    }

    public class Instrumentation
    {
        public string pingUrlBase { get; set; }
        public string pageLoadPingUrl { get; set; }
    }

    public class Querycontext
    {
        public string originalQuery { get; set; }
        public bool isLocationImplied { get; set; }
    }

    public class Places
    {
        public string id { get; set; }
        public Value[] value { get; set; }
    }

    public class Value
    {
        public string _type { get; set; }
        public string name { get; set; }
        public Entitypresentationinfo entityPresentationInfo { get; set; }
        public Address address { get; set; }
        public string telephone { get; set; }
    }

    public class Entitypresentationinfo
    {
        public string entityScenario { get; set; }
        public string[] entityTypeHints { get; set; }
    }

    public class Address
    {
        public string text { get; set; }
        public string streetAddress { get; set; }
        public string addressLocality { get; set; }
        public string addressRegion { get; set; }
        public string postalCode { get; set; }
        public string addressCountry { get; set; }
        public string neighborhood { get; set; }
    }
}