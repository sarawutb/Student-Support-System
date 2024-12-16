using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public class BreachDisciplineMasterCheckListModelDetailsModel : ModifyData
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Id_student_support_master")]
        public int IdStudentSupportMaster { get; set; }

        [JsonProperty("student_support_breach_discipline_Id")]
        public int StudentSupportBreachDisciplineId { get; set; }

        [JsonProperty("breach_discipline_master_Id")]
        public int BreachDisciplineMasterId { get; set; }

        [JsonProperty("breach_discipline_master_other")]
        public string? BreachDisciplineMasterOther { get; set; }

        [JsonProperty("CheckListId")]
        public int CheckListId { get; set; }  
        
        [JsonProperty("CheckListName")]
        public string CheckListName { get; set; }  

        [JsonProperty("CheckListOther")]
        public string? CheckListOther { get; set; }
    }
}
