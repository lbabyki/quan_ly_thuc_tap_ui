using Newtonsoft.Json;

namespace MyWinFormsApp.DataAccess.Models
{
    /// <summary>
    /// DTO cho API Response chung
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu của data</typeparam>
    public class ApiResponse<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("data")]
        public T? Data { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }
    }
}

