using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Newtonsoft.Json;

namespace Pilot.Models
{

    public class Poi
    {
        public string type { get; set; }

        public List<Feature> features { get; set; }
    }

  
    public class Feature
    {
        public string type { get; set; } 

        public Geometry geometry { get; set; }

        public Properties properties { get; set; }

        public string id { get; set; }
    }


    public class Geometry
    {
        public string type { get; set; }

        public List<double> coordinates { get; set; }
    }

    public class Properties
    {
        public string amenity { get; set; }
        public string internet_access { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string geotype { get; set; }
        public int index { get; set; }

        [JsonProperty("addr:housenumber")]
        public string addrhousenumber { get; set; }

        [JsonProperty("addr:street")]
        public string addrstreet { get; set; }
        public string cuisine { get; set; }

        [JsonProperty("name:en")]
        public string nameen { get; set; }

        [JsonProperty("name:tr")]
        public string nametr { get; set; }
        public string opening_hours { get; set; }

        [JsonProperty("name:ru")]
        public string nameru { get; set; }

        [JsonProperty("addr:city")]
        public string addrcity { get; set; }

        [JsonProperty("name:az")]
        public string nameaz { get; set; }
        public string brand { get; set; }

        [JsonProperty("brand:wikidata")]
        public string brandwikidata { get; set; }
        public string outdoor_seating { get; set; }
        public string takeaway { get; set; }
        public string drive_through { get; set; }

        [JsonProperty("diet:vegetarian")]
        public string dietvegetarian { get; set; }

        [JsonProperty("addr:postcode")]
        public string addrpostcode { get; set; }

        [JsonProperty("name:fa")]
        public string namefa { get; set; }
        public string @operator { get; set; }
        public string atm { get; set; }
    }
}

