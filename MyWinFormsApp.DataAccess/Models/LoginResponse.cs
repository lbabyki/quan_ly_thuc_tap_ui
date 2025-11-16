using Newtonsoft.Json;

namespace MyWinFormsApp.DataAccess.Models
{
    /// <summary>
    /// DTO cho Login Response
    /// </summary>
    public class LoginResponse
    {
        [JsonProperty("token")]
        public string? Token { get; set; }

        [JsonProperty("user")]
        public UserDto? User { get; set; }
    }

    /// <summary>
    /// DTO cho User trong Login Response
    /// </summary>
    public class UserDto
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("role")]
        public string? Role { get; set; }

        [JsonProperty("fullName")]
        public string? FullName { get; set; }

        [JsonProperty("userName")]
        public string? UserName { get; set; }

        [JsonProperty("phone")]
        public string? Phone { get; set; }
    }
}

