using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public partial class FileCenterModel : ModifyData
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("name_file")]
        public string NameFile { get; set; }
        
        [JsonProperty("path_file")]
        public string PathFile { get; set; }

        [JsonProperty("extension_file")]
        public string ExtensionFile { get; set; }     
        
        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("size_file")]
        public decimal SizeFile { get; set; }
        
        [JsonProperty("type_file")]
        public string TypeFile { get; set; }
    }
}
