using MyWinFormsApp.DataAccess.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace MyWinFormsApp.DataAccess.Repositories
{
    /// <summary>
    /// UserRepository - Gọi API liên quan đến User
    /// </summary>
    public class UserRepository
    {
        /// <summary>
        /// Đăng nhập qua API
        /// </summary>
        /// <param name="email">Email đăng nhập</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>LoginResponse chứa token và thông tin user</returns>
        public async Task<ApiResponse<LoginResponse>> LoginAsync(string email, string password)
        {
            try
            {
                // Tạo RestClient
                var client = ApiClient.CreateClient();

                // Tạo RestRequest cho endpoint login
                var request = ApiClient.CreateRequest("/v1/api/auth/login", Method.Post);

                // Tạo body request
                var loginRequest = new LoginRequest
                {
                    Email = email,
                    Password = password
                };

                // Thêm body vào request
                request.AddJsonBody(loginRequest);

                // Gọi API
                var response = await client.ExecuteAsync(request);

                // Kiểm tra response
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    // Parse JSON response
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoginResponse>>(response.Content);

                    if (apiResponse != null && apiResponse.Success && apiResponse.Data != null)
                    {
                        // Lưu JWT Token vào ApiClient
                        if (!string.IsNullOrEmpty(apiResponse.Data.Token))
                        {
                            ApiClient.JwtToken = apiResponse.Data.Token;
                        }

                        return apiResponse;
                    }
                    else
                    {
                        return new ApiResponse<LoginResponse>
                        {
                            Success = false,
                            Message = apiResponse?.Message ?? "Đăng nhập thất bại",
                            Error = apiResponse?.Error
                        };
                    }
                }
                else
                {
                    // Xử lý lỗi HTTP
                    return new ApiResponse<LoginResponse>
                    {
                        Success = false,
                        Message = $"Lỗi kết nối: {response.StatusCode}",
                        Error = response.ErrorMessage ?? response.Content
                    };
                }
            }
            catch (Exception ex)
            {
                // Xử lý exception
                return new ApiResponse<LoginResponse>
                {
                    Success = false,
                    Message = "Có lỗi xảy ra khi đăng nhập",
                    Error = ex.Message
                };
            }
        }

        /// <summary>
        /// Đăng xuất
        /// </summary>
        public void Logout()
        {
            ApiClient.ClearToken();
        }
    }
}

