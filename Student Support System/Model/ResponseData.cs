using System;
using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public class ResponseData<T>
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("result")]
        public T? Result { get; set; }

        [JsonProperty("messenger")]
        public string? Messenger { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }
    }
}

