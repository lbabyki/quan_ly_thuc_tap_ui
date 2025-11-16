using RestSharp;
using System;

namespace MyWinFormsApp.DataAccess
{
    /// <summary>
    /// ApiClient - Quản lý kết nối API, BaseUrl và JWT Token
    /// </summary>
    public class ApiClient
    {
        // BaseUrl có thể dễ dàng thay đổi
        public static string BaseUrl { get; set; } = "http://localhost:5000"; // Thay đổi theo API server của bạn

        // Lưu JWT Token sau khi đăng nhập thành công
        private static string? _jwtToken;

        /// <summary>
        /// Lấy hoặc set JWT Token
        /// </summary>
        public static string? JwtToken
        {
            get => _jwtToken;
            set => _jwtToken = value;
        }

        /// <summary>
        /// Tạo RestClient với BaseUrl
        /// </summary>
        public static RestClient CreateClient()
        {
            var options = new RestClientOptions(BaseUrl)
            {
                Timeout = TimeSpan.FromSeconds(30) // 30 seconds timeout
            };
            return new RestClient(options);
        }

        /// <summary>
        /// Tạo RestRequest và tự động thêm Authorization header nếu có JWT Token
        /// </summary>
        /// <param name="resource">Endpoint path (ví dụ: "/v1/api/auth/login")</param>
        /// <param name="method">HTTP Method (GET, POST, PUT, DELETE...)</param>
        /// <returns>RestRequest đã được cấu hình</returns>
        public static RestRequest CreateRequest(string resource, Method method = Method.Get)
        {
            var request = new RestRequest(resource, method);

            // Tự động thêm Authorization header nếu có JWT Token
            if (!string.IsNullOrEmpty(_jwtToken))
            {
                request.AddHeader("Authorization", $"Bearer {_jwtToken}");
            }

            // Thêm Content-Type header
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            return request;
        }

        /// <summary>
        /// Xóa JWT Token (dùng khi logout)
        /// </summary>
        public static void ClearToken()
        {
            _jwtToken = null;
        }

        /// <summary>
        /// Kiểm tra xem đã có JWT Token chưa
        /// </summary>
        public static bool IsAuthenticated()
        {
            return !string.IsNullOrEmpty(_jwtToken);
        }
    }
}

