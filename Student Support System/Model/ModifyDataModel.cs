using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public class ModifyData
    {
        [JsonProperty("CreateBy")]
        public int CreateBy { get; set; }

        [JsonProperty("CreateDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("EditBy")]
        public int? EditBy { get; set; }

        [JsonProperty("EditDate")]
        public DateTime? EditDate { get; set; }
    }
}
