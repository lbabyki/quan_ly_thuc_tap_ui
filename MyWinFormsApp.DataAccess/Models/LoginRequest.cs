using Newtonsoft.Json;

namespace MyWinFormsApp.DataAccess.Models
{
    /// <summary>
    /// DTO cho Login Request
    /// </summary>
    public class LoginRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;
    }
}

