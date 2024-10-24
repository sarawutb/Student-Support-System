using Newtonsoft.Json;

namespace Student_Support_System.Model
{
    public class StudentSupportAddressModel : ModifyData
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Id_student_support_master")]
        public int IdStudentSupportMaster { get; set; }

        [JsonProperty("Id_provinces")]
        public int IdProvinces { get; set; }

        [JsonProperty("Id_districts")]
        public int IdDistricts { get; set; }

        [JsonProperty("Id_subdistricts")]
        public int IdSubdistricts { get; set; }

        [JsonProperty("Village_Name")]
        public string? VillageName { get; set; }

        [JsonProperty("Village_No")]
        public int VillageNo { get; set; }        
        
        [JsonProperty("ZipCode")]
        public string ZipCode { get; set; }
    }
}
