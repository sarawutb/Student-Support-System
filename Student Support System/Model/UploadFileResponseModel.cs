using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public partial class UploadFileResponseModel
    {
        [JsonProperty("data")]
        public List<DataFiles> Data { get; set; }
    }

    public partial class DataFiles
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("pathFile")]
        public string PathFile { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
