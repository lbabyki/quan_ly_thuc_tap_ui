using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using MyWinFormsApp.DataAccess.Models;

namespace MyWinFormsApp.DataAccess.Repositories
{
    /// <summary>
    /// Repository cho Student module - gọi API
    /// </summary>
    public class StudentRepository
    {
        private readonly RestClient _client;
        private readonly string _baseUrl = "http://localhost:5000/v1/api";
        private string? _token;

        public StudentRepository(string? token = null)
        {
            _client = new RestClient(_baseUrl);
            _token = token;
        }

        public void SetToken(string token)
        {
            _token = token;
        }

        private RestRequest CreateRequest(string resource, Method method)
        {
            var request = new RestRequest(resource, method);
            if (!string.IsNullOrEmpty(_token))
            {
                request.AddHeader("Authorization", $"Bearer {_token}");
            }
            request.AddHeader("Content-Type", "application/json");
            return request;
        }

        // Profile APIs
        public async Task<ApiResponse<StudentProfileDto>> GetProfileAsync()
        {
            try
            {
                var request = CreateRequest("/students/profile", Method.Get);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<StudentProfileDto>>(response.Content);
                    return result ?? new ApiResponse<StudentProfileDto> { Success = false, Message = "Invalid response" };
                }

                return new ApiResponse<StudentProfileDto>
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get profile"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<StudentProfileDto>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<object>> UpdateProfileAsync(UpdateStudentProfileDto dto)
        {
            try
            {
                var request = CreateRequest("/students/profile", Method.Put);
                request.AddJsonBody(dto);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<object>>(response.Content);
                    return result ?? new ApiResponse<object> { Success = false, Message = "Invalid response" };
                }

                return new ApiResponse<object>
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to update profile"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        // Registration APIs
        public async Task<ApiResponse<AvailableTopicsResponse>> GetAvailableTopicsAsync()
        {
            try
            {
                var request = CreateRequest("/students/topics/available", Method.Get);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<AvailableTopicsResponse>>(response.Content);
                    return result ?? new ApiResponse<AvailableTopicsResponse> { Success = false, Message = "Invalid response" };
                }

                return new ApiResponse<AvailableTopicsResponse>
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get topics"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<AvailableTopicsResponse>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<InternshipRegistrationDto>> RegisterInternshipAsync(CreateInternshipRegistrationDto dto)
        {
            try
            {
                var request = CreateRequest("/students/registrations", Method.Post);
                request.AddJsonBody(dto);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<InternshipRegistrationDto>>(response.Content);
                    return result ?? new ApiResponse<InternshipRegistrationDto> { Success = false, Message = "Invalid response" };
                }

                return new ApiResponse<InternshipRegistrationDto>
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to register"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<InternshipRegistrationDto>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        // Weekly Report APIs
        public async Task<ApiResponse<List<WeeklyReportDto>>> GetWeeklyReportsAsync()
        {
            try
            {
                var request = CreateRequest("/students/reports", Method.Get);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<List<WeeklyReportDto>>>(response.Content);
                    return result ?? new ApiResponse<List<WeeklyReportDto>> { Success = false, Message = "Invalid response" };
                }

                return new ApiResponse<List<WeeklyReportDto>>
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get reports"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<WeeklyReportDto>>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<WeeklyReportDto>> CreateWeeklyReportAsync(CreateWeeklyReportDto dto)
        {
            try
            {
                var request = CreateRequest("/students/reports", Method.Post);
                request.AddJsonBody(dto);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<WeeklyReportDto>>(response.Content);
                    return result ?? new ApiResponse<WeeklyReportDto> { Success = false, Message = "Invalid response" };
                }

                return new ApiResponse<WeeklyReportDto>
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to create report"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<WeeklyReportDto>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        // Progress APIs
        public async Task<ApiResponse<ProgressResponse>> GetProgressAsync()
        {
            try
            {
                var request = CreateRequest("/students/progress", Method.Get);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<ProgressResponse>>(response.Content);
                    return result ?? new ApiResponse<ProgressResponse> { Success = false, Message = "Invalid response" };
                }

                return new ApiResponse<ProgressResponse>
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get progress"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<ProgressResponse>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        // Grade APIs
        public async Task<ApiResponse<GradesResponse>> GetGradesAsync()
        {
            try
            {
                var request = CreateRequest("/students/grades", Method.Get);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<GradesResponse>>(response.Content);
                    return result ?? new ApiResponse<GradesResponse> { Success = false, Message = "Invalid response" };
                }

                return new ApiResponse<GradesResponse>
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get grades"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GradesResponse>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        // Statistics APIs
        public async Task<ApiResponse<StatisticsResponse>> GetStatisticsAsync()
        {
            try
            {
                var request = CreateRequest("/students/statistics", Method.Get);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    var result = JsonConvert.DeserializeObject<ApiResponse<StatisticsResponse>>(response.Content);
                    return result ?? new ApiResponse<StatisticsResponse> { Success = false, Message = "Invalid response" };
                }

                return new ApiResponse<StatisticsResponse>
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get statistics"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<StatisticsResponse>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
    }

    // DTOs for API responses
    public class StudentProfileDto
    {
        public string Id { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Department { get; set; }
        public int Year { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Description { get; set; }
        public string? CvUrl { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class InternshipRegistrationDto
    {
        public string Id { get; set; } = string.Empty;
        public string TopicId { get; set; } = string.Empty;
        public string TopicTitle { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime RegisteredAt { get; set; }
    }

    public class WeeklyReportDto
    {
        public string Id { get; set; } = string.Empty;
        public int WeekNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Progress { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? LecturerComment { get; set; }
        public string? CompanyComment { get; set; }
        public DateTime? SubmittedAt { get; set; }
    }
}

