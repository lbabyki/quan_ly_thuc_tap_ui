using MyWinFormsApp.DataAccess.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWinFormsApp.DataAccess.Repositories
{
    /// <summary>
    /// Repository xử lý các API calls cho Admin
    /// </summary>
    public class AdminRepository
    {
        /// <summary>
        /// Lấy danh sách tất cả người dùng
        /// </summary>
        public async Task<ApiResponse<List<UserDto>>> GetAllUsersAsync()
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest("/v1/api/admin/users", Method.Get);
                
                var response = await client.ExecuteAsync(request);
                
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<List<UserDto>>>(response.Content) 
                        ?? new ApiResponse<List<UserDto>> { Success = false, Message = "Failed to parse response" };
                }
                else
                {
                    return new ApiResponse<List<UserDto>>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<UserDto>>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }

        /// <summary>
        /// Lấy danh sách người dùng theo role
        /// </summary>
        public async Task<ApiResponse<List<UserDto>>> GetUsersByRoleAsync(string role)
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest($"/v1/api/admin/users?role={role}", Method.Get);
                
                var response = await client.ExecuteAsync(request);
                
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<List<UserDto>>>(response.Content)
                        ?? new ApiResponse<List<UserDto>> { Success = false, Message = "Failed to parse response" };
                }
                else
                {
                    return new ApiResponse<List<UserDto>>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<UserDto>>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }

        /// <summary>
        /// Tạo người dùng mới
        /// </summary>
        public async Task<ApiResponse<UserDto>> CreateUserAsync(UserDto user)
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest("/v1/api/admin/users", Method.Post);
                request.AddJsonBody(user);
                
                var response = await client.ExecuteAsync(request);
                
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<UserDto>>(response.Content)
                        ?? new ApiResponse<UserDto> { Success = false, Message = "Failed to parse response" };
                }
                else
                {
                    return new ApiResponse<UserDto>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<UserDto>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }

        /// <summary>
        /// Cập nhật thông tin người dùng
        /// </summary>
        public async Task<ApiResponse<UserDto>> UpdateUserAsync(string userId, UserDto user)
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest($"/v1/api/admin/users/{userId}", Method.Put);
                request.AddJsonBody(user);

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<UserDto>>(response.Content)
                        ?? new ApiResponse<UserDto> { Success = false, Message = "Failed to parse response" };
                }
                else
                {
                    return new ApiResponse<UserDto>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<UserDto>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }

        /// <summary>
        /// Xóa người dùng
        /// </summary>
        public async Task<ApiResponse<object>> DeleteUserAsync(string userId)
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest($"/v1/api/admin/users/{userId}", Method.Delete);

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<object>>(response.Content)
                        ?? new ApiResponse<object> { Success = false, Message = "Failed to parse response" };
                }
                else
                {
                    return new ApiResponse<object>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<object>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }

        /// <summary>
        /// Reset mật khẩu người dùng
        /// </summary>
        public async Task<ApiResponse<object>> ResetPasswordAsync(string userId)
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest($"/v1/api/admin/users/{userId}/reset-password", Method.Post);

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<object>>(response.Content)
                        ?? new ApiResponse<object> { Success = false, Message = "Failed to parse response" };
                }
                else
                {
                    return new ApiResponse<object>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<object>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }

        /// <summary>
        /// Lấy danh sách đề tài thực tập
        /// </summary>
        public async Task<ApiResponse<List<InternshipTopicDto>>> GetTopicsAsync(string? status = null)
        {
            try
            {
                var client = ApiClient.CreateClient();
                var url = "/v1/api/admin/topics";
                if (!string.IsNullOrEmpty(status))
                {
                    url += $"?status={status}";
                }
                var request = ApiClient.CreateRequest(url, Method.Get);

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<List<InternshipTopicDto>>>(response.Content)
                        ?? new ApiResponse<List<InternshipTopicDto>> { Success = false, Message = "Failed to parse response" };
                }
                else
                {
                    return new ApiResponse<List<InternshipTopicDto>>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<InternshipTopicDto>>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }

        /// <summary>
        /// Tạo đề tài mới
        /// </summary>
        public async Task<ApiResponse<InternshipTopicDto>> CreateTopicAsync(InternshipTopicDto topic)
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest("/v1/api/admin/topics", Method.Post);
                request.AddJsonBody(topic);

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<InternshipTopicDto>>(response.Content)
                        ?? new ApiResponse<InternshipTopicDto> { Success = false, Message = "Failed to parse response" };
                }
                else
                {
                    return new ApiResponse<InternshipTopicDto>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<InternshipTopicDto>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }

        /// <summary>
        /// Cập nhật đề tài
        /// </summary>
        public async Task<ApiResponse<InternshipTopicDto>> UpdateTopicAsync(string topicId, InternshipTopicDto topic)
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest($"/v1/api/admin/topics/{topicId}", Method.Put);
                request.AddJsonBody(topic);

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<InternshipTopicDto>>(response.Content)
                        ?? new ApiResponse<InternshipTopicDto> { Success = false, Message = "Failed to parse response" };
                }
                else
                {
                    return new ApiResponse<InternshipTopicDto>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<InternshipTopicDto>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }

        /// <summary>
        /// Duyệt đề tài thực tập
        /// </summary>
        public async Task<ApiResponse<InternshipTopicDto>> ApproveTopicAsync(string topicId)
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest($"/v1/api/admin/topics/{topicId}/approve", Method.Post);

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<InternshipTopicDto>>(response.Content)
                        ?? new ApiResponse<InternshipTopicDto> { Success = false, Message = "Failed to parse response" };
                }
                else
                {
                    return new ApiResponse<InternshipTopicDto>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<InternshipTopicDto>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }

        /// <summary>
        /// Từ chối đề tài thực tập
        /// </summary>
        public async Task<ApiResponse<InternshipTopicDto>> RejectTopicAsync(string topicId, string reason)
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest($"/v1/api/admin/topics/{topicId}/reject", Method.Post);
                request.AddJsonBody(new { reason });

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<InternshipTopicDto>>(response.Content)
                        ?? new ApiResponse<InternshipTopicDto> { Success = false, Message = "Failed to parse response" };
                }
                else
                {
                    return new ApiResponse<InternshipTopicDto>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<InternshipTopicDto>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }

        /// <summary>
        /// Lấy nhật ký hệ thống
        /// </summary>
        public async Task<ApiResponse<List<SystemLogDto>>> GetSystemLogsAsync(int limit = 100)
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest($"/v1/api/admin/logs?limit={limit}", Method.Get);

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<List<SystemLogDto>>>(response.Content)
                        ?? new ApiResponse<List<SystemLogDto>> { Success = false, Message = "Failed to parse response" };
                }
                else
                {
                    return new ApiResponse<List<SystemLogDto>>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<SystemLogDto>>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }

        /// <summary>
        /// Lấy thống kê hệ thống
        /// </summary>
        public async Task<ApiResponse<StatisticsDto>> GetStatisticsAsync()
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest("/v1/api/admin/statistics", Method.Get);

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<StatisticsDto>>(response.Content)
                        ?? new ApiResponse<StatisticsDto> { Success = false, Message = "Failed to parse response" };
                }
                else
                {
                    return new ApiResponse<StatisticsDto>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<StatisticsDto>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }
    }
}

