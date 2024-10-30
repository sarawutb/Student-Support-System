using System;
using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public class PovinceModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("name_in_thai")]
        public string NameInThai { get; set; }

        [JsonProperty("name_in_english")]
        public string NameInEnglish { get; set; }
    }
}

