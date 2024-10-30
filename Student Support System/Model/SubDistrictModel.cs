using System;
using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public partial class SubDistrictModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name_in_thai")]
        public string NameInThai { get; set; }

        [JsonProperty("name_in_english")]
        public string NameInEnglish { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("district_id")]
        public int DistrictId { get; set; }

        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }
    }
}

