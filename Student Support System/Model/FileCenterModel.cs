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
        public string? ExtensionFile { get; private set; }

        private string? _nameFile;
        [JsonProperty("name_file")]
        public string? NameFile
        {
            get => _nameFile;
            set
            {
                _nameFile = value;
                if (_nameFile.Contains("."))
                {
                    ExtensionFile = _nameFile.Split('.').LastOrDefault();
                }
            }
        }

        [JsonProperty("name_file_old")]
        public string? NameFileOld { get; set; }

        [JsonProperty("path_file")]
        public string? PathFile { get; set; }

        [JsonProperty("size_file")]
        public decimal SizeFile { get; set; }

        [JsonProperty("type_file")]
        public int? TypeFile { get; set; }

        [JsonProperty("urlPath")]
        public string? UrlPath { get; set; }
    }

    public class RenoveFileModel
    {
        public string fileName { get; set; }
        public string fileDate { get; set; }
    }
}