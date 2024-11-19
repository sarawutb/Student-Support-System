using System;
using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public partial class BreachDisciplineMasterModel : ModifyData
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("IsUse")]
        public int IsUse { get; set; }

        [JsonProperty("IsOther")]
        public bool IsOther { get; set; }
    }
}

