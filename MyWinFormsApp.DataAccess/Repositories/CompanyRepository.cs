using System;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using MyWinFormsApp.DataAccess.Models;

namespace MyWinFormsApp.DataAccess.Repositories
{
    /// <summary>
    /// Repository cho Company API
    /// </summary>
    public class CompanyRepository
    {
        private readonly RestClient _client;
        private readonly string? _token;

        public CompanyRepository(string? token = null)
        {
            _client = new RestClient("http://localhost:5000/v1/api");
            _token = token;
        }

        private RestRequest CreateRequest(string resource, Method method)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Content-Type", "application/json");

            if (!string.IsNullOrEmpty(_token))
            {
                request.AddHeader("Authorization", $"Bearer {_token}");
            }

            return request;
        }

        // Get student confirmations
        public async Task<StudentConfirmationsResponse> GetStudentConfirmationsAsync(string? status = null)
        {
            try
            {
                var resource = "/company/confirmations";
                if (!string.IsNullOrEmpty(status))
                {
                    resource += $"?status={status}";
                }

                var request = CreateRequest(resource, Method.Get);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonConvert.DeserializeObject<StudentConfirmationsResponse>(response.Content)
                        ?? new StudentConfirmationsResponse { Success = false, Message = "Invalid response" };
                }

                return new StudentConfirmationsResponse
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get confirmations"
                };
            }
            catch (Exception ex)
            {
                return new StudentConfirmationsResponse
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        // Confirm student
        public async Task<ApiResponse<object>> ConfirmStudentAsync(ConfirmStudentDto dto)
        {
            try
            {
                var request = CreateRequest("/company/confirmations/confirm", Method.Post);
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
                    Message = response.ErrorMessage ?? "Failed to confirm student"
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

        // Get student evaluations
        public async Task<StudentEvaluationsResponse> GetStudentEvaluationsAsync(string? status = null)
        {
            try
            {
                var resource = "/company/evaluations";
                if (!string.IsNullOrEmpty(status))
                {
                    resource += $"?status={status}";
                }

                var request = CreateRequest(resource, Method.Get);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonConvert.DeserializeObject<StudentEvaluationsResponse>(response.Content)
                        ?? new StudentEvaluationsResponse { Success = false, Message = "Invalid response" };
                }

                return new StudentEvaluationsResponse
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get evaluations"
                };
            }
            catch (Exception ex)
            {
                return new StudentEvaluationsResponse
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        // Submit evaluation
        public async Task<ApiResponse<object>> SubmitEvaluationAsync(SubmitEvaluationDto dto)
        {
            try
            {
                var request = CreateRequest("/company/evaluations/submit", Method.Post);
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
                    Message = response.ErrorMessage ?? "Failed to submit evaluation"
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

        // Get company reports
        public async Task<CompanyReportsResponse> GetReportsAsync()
        {
            try
            {
                var request = CreateRequest("/company/reports", Method.Get);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonConvert.DeserializeObject<CompanyReportsResponse>(response.Content)
                        ?? new CompanyReportsResponse { Success = false, Message = "Invalid response" };
                }

                return new CompanyReportsResponse
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get reports"
                };
            }
            catch (Exception ex)
            {
                return new CompanyReportsResponse
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        // Submit report
        public async Task<ApiResponse<object>> SubmitReportAsync(SubmitReportDto dto)
        {
            try
            {
                var request = CreateRequest("/company/reports/submit", Method.Post);
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
                    Message = response.ErrorMessage ?? "Failed to submit report"
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

        // Get internship topics
        public async Task<InternshipTopicsResponse> GetTopicsAsync()
        {
            try
            {
                var request = CreateRequest("/company/topics", Method.Get);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonConvert.DeserializeObject<InternshipTopicsResponse>(response.Content)
                        ?? new InternshipTopicsResponse { Success = false, Message = "Invalid response" };
                }

                return new InternshipTopicsResponse
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to get topics"
                };
            }
            catch (Exception ex)
            {
                return new InternshipTopicsResponse
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        // Create topic
        public async Task<ApiResponse<object>> CreateTopicAsync(CreateTopicDto dto)
        {
            try
            {
                var request = CreateRequest("/company/topics/create", Method.Post);
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
                    Message = response.ErrorMessage ?? "Failed to create topic"
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

        // Update topic
        public async Task<ApiResponse<object>> UpdateTopicAsync(string topicId, CreateTopicDto dto)
        {
            try
            {
                var request = CreateRequest($"/company/topics/{topicId}", Method.Put);
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
                    Message = response.ErrorMessage ?? "Failed to update topic"
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

        // Delete topic
        public async Task<ApiResponse<object>> DeleteTopicAsync(string topicId)
        {
            try
            {
                var request = CreateRequest($"/company/topics/{topicId}", Method.Delete);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonConvert.DeserializeObject<ApiResponse<object>>(response.Content)
                        ?? new ApiResponse<object> { Success = false, Message = "Invalid response" };
                }

                return new ApiResponse<object>
                {
                    Success = false,
                    Message = response.ErrorMessage ?? "Failed to delete topic"
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
    }
}

