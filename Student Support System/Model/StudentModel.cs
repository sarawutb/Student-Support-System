using Newtonsoft.Json;

namespace Student_Support_System.Model
{
    public class StudentModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("id_std")]
        public string IdStd { get; set; }

        [JsonProperty("year_std")]
        public string YearStd { get; set; }

        [JsonProperty("name_std")]
        private string _fullName;
        public string fullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                SetNameStd();
            }
        }
        public string firstNameStd { get; set; }
        public string lastNameStd { get; set; }

        [JsonProperty("branch_id_std")]
        public int BranchIdStd { get; set; }
        public int BranchNameStd { get; set; }

        [JsonProperty("genre_std")]
        public int GenreStd { get; set; }

        [JsonProperty("degree_std")]
        public int DegreeStd { get; set; }

        [JsonProperty("section_std")]
        public string SectionStd { get; set; }

        [JsonProperty("password_std")]
        public string PasswordStd { get; set; }

        [JsonProperty("gender_std")]
        public int GenderStd { get; set; }

        private void SetNameStd()
        {
            var lst = _fullName.Split(' ');
            if(lst.Length >= 2)
            {
                firstNameStd = lst[0];
                lastNameStd = lst[1];
            }
        }
    }
}
