using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public class BreachDisciplineMasterCheckListModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }   
        
        [JsonProperty("Id_student_support_master")]
        public int IdStudentSupportMaster { get; set; }

        [JsonProperty("Qty")]
        public int Qty { get; set; }

        [JsonProperty("CreateBy")]
        public int CreateBy { get; set; }

        [JsonProperty("Id_student_support_breach_discipline_checklist")]
        public List<StudentSupportBreachDisciplineChecklist> StudentSupportBreachDisciplineChecklist { get; set; }
    }

    public class StudentSupportBreachDisciplineChecklist
    {
        [JsonProperty("CheckLsitId")]
        public int CheckLsitId { get; set; }

        [JsonProperty("Other")]
        public string? Other { get; set; }
    }
}
