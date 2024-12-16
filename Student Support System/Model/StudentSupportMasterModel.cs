using Newtonsoft.Json;
using StudentSupportSystem.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace StudentSupportSystem.Model
{
    public class StudentSupportMasterModel : ModifyData
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("IdStd")]
        public int? IdStd { get; set; }

        [JsonProperty("StudentProfile")]
        public StudentModel? StudentProfile { get; set; }

        [JsonProperty("StdPrefix")]
        public int? StdPrefix { get; set; }

        [JsonProperty("Std_NicName")]
        public string? StdNicName { get; set; }

        [JsonProperty("Std_Age")]
        public int? StdAge { get; set; }

        [JsonProperty("Qty")]
        public int? Qty { get; set; }

        private DateTime? _stdDateOfBirthEN;
        [JsonProperty("Std_DateOfBirth")]
        public DateTime? StdDateOfBirthEN
        {
            get => _stdDateOfBirthEN;
            set
            {
                _stdDateOfBirthEN = value;
                SetStdDateOfBirthSeparate();
            }
        }

        private DateTime? _stdDateOfBirthTH;
        [JsonProperty("Std_DateOfBirth_TH")]
        public DateTime? StdDateOfBirthTH
        {
            get => _stdDateOfBirthTH;
            set
            {
                _stdDateOfBirthTH = value;
            }
        }
        public StdDateOfBirthModel? StdDateOfBirthSeparate { get; set; }

        [JsonProperty("Currently_living_with")]
        public int? CurrentlyLivingWith { get; set; }

        [JsonProperty("Currently_living_with_other")]
        public string? CurrentlyLivingWithOther { get; set; }

        [JsonProperty("Id_Teacher")]
        public int? IdTeacher { get; set; }

        [JsonProperty("Parents_Phone")]
        public string? ParentsPhone { get; set; }

        [JsonProperty("Std_Phone")]
        public string? StdPhone { get; set; }

        [JsonProperty("Id_File_Cener")]
        public int? Id_File_Cener { get; set; }

        [JsonProperty("Std_Address")]
        public StudentSupportAddressModel? StdAddress { get; set; }

        [JsonProperty("Std_FileCenter")]
        public FileCenterModel? Std_FileCenter { get; set; }

        [JsonProperty("BreachDisciplineMasterCheckList")]
        public BreachDisciplineMasterCheckListModel? BreachDisciplineMasterCheckList { get; set; }

        private void SetStdDateOfBirthSeparate()
        {
            if (StdDateOfBirthEN != null)
                StdDateOfBirthSeparate = new StdDateOfBirthModel
                {
                    Day = StdDateOfBirthEN.Value.Day,
                    Month = StdDateOfBirthEN.Value.Month,
                    Year = StdDateOfBirthEN.Value.Year,
                };
        }
    }

    public class StdDateOfBirthModel : BaseViewModel
    {
        [Required(ErrorMessage = "กรุณากรอกวันที่")]
        private int? _day;
        public int? Day
        {
            get => _day;
            set
            {
                _day = value;
                StdAge = CalculateAge(this);
                OnPropertyChanged();
            }
        }
        private int? _month;
        public int? Month
        {
            get => _month;
            set
            {
                _month = value;
                StdAge = CalculateAge(this);
                OnPropertyChanged();
            }
        }
        private int? _year;
        public int? Year
        {
            get => _year;
            set
            {
                _year = value;
                StdAge = CalculateAge(this);
                OnPropertyChanged();
            }
        }
        private int? _stdAge;
        public int? StdAge
        {
            get => _stdAge;
            set
            {
                _stdAge = value;
                OnPropertyChanged();
            }
        }


        private int? CalculateAge(StdDateOfBirthModel dateOfBirth)
        {
            if (dateOfBirth == null || dateOfBirth.Day == null || dateOfBirth.Month == null || dateOfBirth.Year == null)
            {
                return null;
            }
            int birthYear = dateOfBirth.Year.Value - 543;
            int birthMonth = dateOfBirth.Month.Value;
            int birthDay = dateOfBirth.Day.Value;
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthYear;
            if (currentDate.Month < birthMonth ||
                (currentDate.Month == birthMonth && currentDate.Day < birthDay))
            {
                age--;
            }

            return age;
        }
    }
}
