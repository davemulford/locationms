﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace locationms
{
    public class GeoLocation
    {
        [JsonProperty("ip")]
        public string IP { get; set; }

        [JsonProperty("country_code")]

        public string CountryCode { get; set; }

        [JsonProperty("country_name")]

        public string CountryName { get; set; }

        [JsonProperty("region_code")]

        public string RegionCode { get; set; }

        [JsonProperty("region_name")]

        public string RegionName { get; set; }

        [JsonProperty("city")]

        public string City { get; set; }

        [JsonProperty("zip")]

        public string Zip { get; set; }

        [JsonProperty("latitude")]

        public float Latitude { get; set; }

        [JsonProperty("longitude")]

        public float Longitude { get; set; }

        private GeoLocation() { }

        public static async Task<GeoLocation> QueryGeographicalLocationAsync(string ipAddress)
        {
            HttpClient client = new HttpClient();
            string url = "http://api.ipstack.com/" + ipAddress + "?access_key=" + Environment.GetEnvironmentVariable("ACCESS_KEY");
            Console.WriteLine(url);
            string result = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<GeoLocation>(result);
        }
    }
}