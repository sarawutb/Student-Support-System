using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public class StudentModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("id_std")]
        public string? IdStd { get; set; }

        [JsonProperty("year_std")]
        public string? YearStd { get; set; }

        [JsonProperty("name_std")]
        private string _fullName;
        public string fullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
            }
        }
        public string? firstNameStd { get; set; }
        public string? lastNameStd { get; set; }

        [JsonProperty("branch_id_std")]
        public int? BranchIdStd { get; set; }

        public string? BranchNameStd { get; set; }

        [JsonProperty("genre_std")]
        public int? GenreStd { get; set; }

        [JsonProperty("degree_std")]
        public int? DegreeStd { get; set; }

        [JsonProperty("section_std")]
        public string? SectionStd { get; set; }

        [JsonProperty("password_std")]
        public string PasswordStd { get; set; }

        [JsonProperty("gender_std")]
        public int? GenderStd { get; set; }

        public void SetNameStd()
        {
            string[] parts = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            firstNameStd = parts[0];
            lastNameStd = parts.Length > 1 ? parts[1] : string.Empty;
        }
    }
}
