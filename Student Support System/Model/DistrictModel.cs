using System;
using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public partial class DistrictModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("name_in_thai")]
        public string NameInThai { get; set; }

        [JsonProperty("name_in_english")]
        public string NameInEnglish { get; set; }

        [JsonProperty("province_id")]
        public long ProvinceId { get; set; }
    }
}

