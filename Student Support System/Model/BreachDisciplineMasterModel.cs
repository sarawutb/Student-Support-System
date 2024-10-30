using System;
using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public partial class BreachDisciplineMasterModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("IsUse")]
        public int IsUse { get; set; }

        [JsonProperty("CreateBy")]
        public int CreateBy { get; set; }

        [JsonProperty("CreateDate")]
        public string CreateDate { get; set; }

        [JsonProperty("EditBy")]
        public int? EditBy { get; set; }

        [JsonProperty("EditDate")]
        public string? EditDate { get; set; }
    }
}

