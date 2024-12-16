using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public partial class TeacherModel
    {
        [JsonProperty("id_teacher")]
        public int IdTeacher { get; set; }

        [JsonProperty("name_teacher")]
        public string? fullName { get; set; }
        public string? firstNameTeacher { get; set; }
        public string? lastNameTeacher { get; set; }

        [JsonProperty("email_teacher")]
        public string? EmailTeacher { get; set; }

        [JsonProperty("password_teacher")]
        public string PasswordTeacher { get; set; }

        [JsonProperty("status_teacher")]
        public int StatusTeacher { get; set; }

        [JsonProperty("gender_teacher")]
        public int? GenderTeacher { get; set; }
        public void SetNameTeacher()
        {
            if (!string.IsNullOrEmpty(fullName))
            {
                string[] parts = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                firstNameTeacher = parts[0];
                lastNameTeacher = parts.Length > 1 ? parts[1] : string.Empty;
            }
        }
    }
}
