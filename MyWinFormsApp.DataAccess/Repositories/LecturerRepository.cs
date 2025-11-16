using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWinFormsApp.DataAccess.Models;
using RestSharp;
using Newtonsoft.Json;

namespace MyWinFormsApp.DataAccess.Repositories
{
    /// <summary>
    /// Repository cho Lecturer API
    /// </summary>
    public class LecturerRepository
    {
        private readonly RestClient _client;
        private readonly string? _token;

        public LecturerRepository(string? token = null)
        {
            _client = new RestClient("http://localhost:5000/v1/api");
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

        /// <summary>
        /// Lấy danh sách sinh viên hướng dẫn
        /// </summary>
        public async Task<SupervisedStudentsResponse> GetSupervisedStudentsAsync(string? status = null)
        {
            try
            {
                var request = CreateRequest("/lecturer/students", Method.Get);
                if (!string.IsNullOrEmpty(status))
                {
                    request.AddQueryParameter("status", status);
                }

                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonConvert.DeserializeObject<SupervisedStudentsResponse>(response.Content)
                        ?? new SupervisedStudentsResponse { Success = false, Message = "Invalid response" };
                }

                return new SupervisedStudentsResponse
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get supervised students"
                };
            }
            catch (Exception ex)
            {
                return new SupervisedStudentsResponse
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Lấy danh sách báo cáo sinh viên
        /// </summary>
        public async Task<StudentReportsResponse> GetStudentReportsAsync(string? studentId = null, string? status = null)
        {
            try
            {
                var request = CreateRequest("/lecturer/reports", Method.Get);
                if (!string.IsNullOrEmpty(studentId))
                {
                    request.AddQueryParameter("studentId", studentId);
                }
                if (!string.IsNullOrEmpty(status))
                {
                    request.AddQueryParameter("status", status);
                }

                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonConvert.DeserializeObject<StudentReportsResponse>(response.Content)
                        ?? new StudentReportsResponse { Success = false, Message = "Invalid response" };
                }

                return new StudentReportsResponse
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get reports"
                };
            }
            catch (Exception ex)
            {
                return new StudentReportsResponse
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Phản hồi báo cáo
        /// </summary>
        public async Task<ApiResponse<object>> ReviewReportAsync(ReviewReportDto dto)
        {
            try
            {
                var request = CreateRequest("/lecturer/reports/review", Method.Post);
                request.AddJsonBody(dto);

                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonConvert.DeserializeObject<ApiResponse<object>>(response.Content)
                        ?? new ApiResponse<object> { Success = false, Message = "Invalid response" };
                }

                return new ApiResponse<object>
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to review report"
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

        /// <summary>
        /// Lấy danh sách điểm
        /// </summary>
        public async Task<StudentGradingsResponse> GetStudentGradingsAsync()
        {
            try
            {
                var request = CreateRequest("/lecturer/gradings", Method.Get);

                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonConvert.DeserializeObject<StudentGradingsResponse>(response.Content)
                        ?? new StudentGradingsResponse { Success = false, Message = "Invalid response" };
                }

                return new StudentGradingsResponse
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get gradings"
                };
            }
            catch (Exception ex)
            {
                return new StudentGradingsResponse { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        /// <summary>
        /// Nhập điểm
        /// </summary>
        public async Task<ApiResponse<object>> SubmitGradeAsync(SubmitGradeDto dto)
        {
            try
            {
                var request = CreateRequest("/lecturer/gradings/submit", Method.Post);
                request.AddJsonBody(dto);

                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonConvert.DeserializeObject<ApiResponse<object>>(response.Content)
                        ?? new ApiResponse<object> { Success = false, Message = "Invalid response" };
                }

                return new ApiResponse<object>
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to submit grade"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<object> { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        /// <summary>
        /// Lấy danh sách lịch bảo vệ
        /// </summary>
        public async Task<DefenseSchedulesResponse> GetDefenseSchedulesAsync()
        {
            try
            {
                var request = CreateRequest("/lecturer/defense-schedules", Method.Get);

                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonConvert.DeserializeObject<DefenseSchedulesResponse>(response.Content)
                        ?? new DefenseSchedulesResponse { Success = false, Message = "Invalid response" };
                }

                return new DefenseSchedulesResponse
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get defense schedules"
                };
            }
            catch (Exception ex)
            {
                return new DefenseSchedulesResponse { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        /// <summary>
        /// Tạo lịch bảo vệ
        /// </summary>
        public async Task<ApiResponse<object>> CreateDefenseScheduleAsync(CreateDefenseScheduleDto dto)
        {
            try
            {
                var request = CreateRequest("/lecturer/defense-schedules/create", Method.Post);
                request.AddJsonBody(dto);

                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonConvert.DeserializeObject<ApiResponse<object>>(response.Content)
                        ?? new ApiResponse<object> { Success = false, Message = "Invalid response" };
                }

                return new ApiResponse<object>
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to create defense schedule"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<object> { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        /// <summary>
        /// Lấy thống kê
        /// </summary>
        public async Task<LecturerStatisticsResponse> GetStatisticsAsync()
        {
            try
            {
                var request = CreateRequest("/lecturer/statistics", Method.Get);

                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonConvert.DeserializeObject<LecturerStatisticsResponse>(response.Content)
                        ?? new LecturerStatisticsResponse { Success = false, Message = "Invalid response" };
                }

                return new LecturerStatisticsResponse
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get statistics"
                };
            }
            catch (Exception ex)
            {
                return new LecturerStatisticsResponse { Success = false, Message = $"Error: {ex.Message}" };
            }
        }
    }
}

