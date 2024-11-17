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
        public string NameStd { get; set; }

        [JsonProperty("firstNameStd")]
        public string? firstNameStd { get; set; }

        [JsonProperty("lastNameStd")]
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

        public string GenderDisplayTh()
        {
            string _gender = string.Empty;
            if (GenderStd != null)
            {
                if (GenderStd == 1)
                {
                    _gender = "นาย";
                }
                else
                {
                    _gender = "นางสาว";
                }
            }
            return _gender;
        }
        
        public string GenreStdDisplayTh()
        {
            string _genreStd = string.Empty;
            if (GenderStd != null)
            {
                if (GenreStd == 1)
                {
                    _genreStd = "ปวช.";
                }
                else
                {
                    _genreStd = "ปวส.";
                }
            }
            return _genreStd;
        }
    }
}
