using Newtonsoft.Json;

namespace Student_Support_System.Model
{
    public class StudentSupportMasterModel : ModifyData
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("IdStd")]
        public int IdStd { get; set; }

        [JsonProperty("StdPrefix")]
        public int StdPrefix { get; set; }

        [JsonProperty("Std_NicName")]
        public string? StdNicName { get; set; }

        [JsonProperty("Std_Age")]
        public int StdAge { get; set; }

        private DateTime _stdDateOfBirth;
        [JsonProperty("Std_DateOfBirth")]
        public DateTime StdDateOfBirth
        {
            get => _stdDateOfBirth;
            set
            {
                _stdDateOfBirth = value;
                SetStdDateOfBirthSeparate();
            }
        }
        public StdDateOfBirthModel StdDateOfBirthSeparate { get; set; }

        [JsonProperty("Currently_living_with")]
        public int CurrentlyLivingWith { get; set; }

        [JsonProperty("Currently_living_with_other")]
        public string? CurrentlyLivingWithOther { get; set; }

        [JsonProperty("Id_Teacher")]
        public int IdTeacher { get; set; }

        [JsonProperty("Parents_Phone")]
        public string? ParentsPhone { get; set; }

        [JsonProperty("Std_Phone")]
        public string? StdPhone { get; set; }

        [JsonProperty("Std_Address")]
        public StudentSupportAddressModel StdAddress { get; set; }

        private void SetStdDateOfBirthSeparate()
        {
            StdDateOfBirthSeparate = new StdDateOfBirthModel
            {
                Day = _stdDateOfBirth.Day,
                Month = _stdDateOfBirth.Month,
                Year = _stdDateOfBirth.Year,
            };
        }
    }

    public class StdDateOfBirthModel
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
