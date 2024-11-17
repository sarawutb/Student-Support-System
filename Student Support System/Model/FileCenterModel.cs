using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public partial class FileCenterModel : ModifyData
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("content_type")]
        public string? ContentType { get; set; }

        [JsonProperty("extension_file")]
        public string? ExtensionFile { get; set; }

        [JsonProperty("name_file")]
        public string? NameFile { get; set; }

        [JsonProperty("name_file_old")]
        public string? NameFileOld { get; set; }

        [JsonProperty("path_file")]
        public string? PathFile { get; set; }

        [JsonProperty("size_file")]
        public double SizeFile { get; set; }

        [JsonProperty("type_file")]
        public string? TypeFile { get; set; }

        [JsonProperty("urlPath")]
        public string? UrlPath { get; set; }
    }
}