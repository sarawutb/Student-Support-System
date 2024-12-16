using Newtonsoft.Json;

namespace StudentSupportSystem.Model
{
    public partial class LoginModel
    {
        [JsonProperty("data")]
        public LoginModelData Data { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public partial class LoginModelData
    {
        [JsonProperty("id_teacher")]
        public int IdTeacher { get; set; }

        [JsonProperty("name_teacher")]
        public string NameTeacher { get; set; }

        [JsonProperty("email_teacher")]
        public string EmailTeacher { get; set; }

        [JsonProperty("password_teacher")]
        public string PasswordTeacher { get; set; }

        [JsonProperty("status_teacher")]
        public int StatusTeacher { get; set; }
    }

    public class FormLoginModel
    {
        public string? email { get; set; }
        public string? password { get; set; }
    }
}
