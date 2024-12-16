using Newtonsoft.Json;
using StudentSupportSystem.ViewModel;

namespace StudentSupportSystem.Model
{
    public class BreachDisciplineModel : ModifyData
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Id_student_support_master")]
        public int IdStudentSupportMaster { get; set; }

        [JsonProperty("Qty")]
        public int Qty { get; set; }

        [JsonProperty("CreateByName")]
        public string CreateByName { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDetail { get; set; }

        private List<BreachDisciplineMasterModel> _lstBreachDisciplineMasters = new List<BreachDisciplineMasterModel>();
        public List<BreachDisciplineMasterModel> lstBreachDisciplineMasters
        {
            get => _lstBreachDisciplineMasters;
            set
            {
                _lstBreachDisciplineMasters = value;
                if (_lstBreachDisciplineMasters != null)
                {
                    JsonlstBreachDisciplineMasters = JsonConvert.SerializeObject(_lstBreachDisciplineMasters);
                }
            }
        }
        public string JsonlstBreachDisciplineMasters = "[]";
        private List<BreachDisciplineMasterCheckListModelDetailsModel> _lstCheckListModelDetailsModels = new List<BreachDisciplineMasterCheckListModelDetailsModel>();
        public List<BreachDisciplineMasterCheckListModelDetailsModel> lstCheckListModelDetailsModels
        {
            get => _lstCheckListModelDetailsModels;
            set
            {
                _lstCheckListModelDetailsModels = value;
                if (_lstCheckListModelDetailsModels != null)
                {
                    JsonlstCheckListModelDetailsModels = JsonConvert.SerializeObject(_lstCheckListModelDetailsModels);
                }
            }
        }
        public string JsonlstCheckListModelDetailsModels = "[]";
    }
}
