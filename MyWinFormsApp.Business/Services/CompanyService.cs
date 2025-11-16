using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWinFormsApp.Business.Interfaces;
using MyWinFormsApp.Business.Models;
using MyWinFormsApp.DataAccess.Models;
using MyWinFormsApp.DataAccess.Repositories;

namespace MyWinFormsApp.Business.Services
{
    /// <summary>
    /// Service cho Company module
    /// </summary>
    public class CompanyService
    {
        private readonly CompanyRepository _repository;
        private readonly ICompanyDataProvider? _mockDataProvider;
        private readonly bool _useMockData;

        public CompanyService(string? token = null, bool useMockData = false, ICompanyDataProvider? mockDataProvider = null)
        {
            _repository = new CompanyRepository(token);
            _useMockData = useMockData;
            _mockDataProvider = mockDataProvider;
        }

        // Get profile
        public async Task<(bool Success, string Message, CompanyProfile? Data)> GetProfileAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetProfile());
            }

            // TODO: Implement API call when backend is ready
            return (false, "API not implemented yet", null);
        }

        // Get student confirmations
        public async Task<(bool Success, string Message, List<StudentConfirmation> Data)> GetStudentConfirmationsAsync(string? status = null)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetStudentConfirmations(status));
            }

            try
            {
                var response = await _repository.GetStudentConfirmationsAsync(status);
                if (response.Success)
                {
                    var confirmations = response.Confirmations.Select(MapToStudentConfirmation).ToList();
                    return (true, response.Message ?? "Success", confirmations);
                }
                return (false, response.Message ?? "Failed", new List<StudentConfirmation>());
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", new List<StudentConfirmation>());
            }
        }

        // Confirm student
        public async Task<(bool Success, string Message)> ConfirmStudentAsync(string studentId, string status, string? supervisor, string? notes)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.ConfirmStudent(studentId, status, supervisor, notes));
            }

            try
            {
                var dto = new ConfirmStudentDto
                {
                    StudentId = studentId,
                    Status = status,
                    Supervisor = supervisor,
                    Notes = notes
                };

                var response = await _repository.ConfirmStudentAsync(dto);
                return (response.Success, response.Message ?? "Failed");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        // Get student evaluations
        public async Task<(bool Success, string Message, List<StudentEvaluation> Data)> GetStudentEvaluationsAsync(string? status = null)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetStudentEvaluations(status));
            }

            try
            {
                var response = await _repository.GetStudentEvaluationsAsync(status);
                if (response.Success)
                {
                    var evaluations = response.Evaluations.Select(MapToStudentEvaluation).ToList();
                    return (true, response.Message ?? "Success", evaluations);
                }
                return (false, response.Message ?? "Failed", new List<StudentEvaluation>());
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", new List<StudentEvaluation>());
            }
        }

        // Submit evaluation
        public async Task<(bool Success, string Message)> SubmitEvaluationAsync(string studentId, decimal attendanceScore, decimal attitudeScore, decimal skillScore, decimal resultScore, string? comment)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.SubmitEvaluation(studentId, attendanceScore, attitudeScore, skillScore, resultScore, comment));
            }

            try
            {
                var dto = new SubmitEvaluationDto
                {
                    StudentId = studentId,
                    AttendanceScore = attendanceScore,
                    AttitudeScore = attitudeScore,
                    SkillScore = skillScore,
                    ResultScore = resultScore,
                    Comment = comment
                };

                var response = await _repository.SubmitEvaluationAsync(dto);
                return (response.Success, response.Message ?? "Failed");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        // Get reports
        public async Task<(bool Success, string Message, List<CompanyReport> Data)> GetReportsAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetReports());
            }

            try
            {
                var response = await _repository.GetReportsAsync();
                if (response.Success)
                {
                    var reports = response.Reports.Select(MapToCompanyReport).ToList();
                    return (true, response.Message ?? "Success", reports);
                }
                return (false, response.Message ?? "Failed", new List<CompanyReport>());
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", new List<CompanyReport>());
            }
        }

        // Submit report
        public async Task<(bool Success, string Message)> SubmitReportAsync(string title, string content, string period, int totalStudents, int completedStudents, List<string> attachments)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.SubmitReport(title, content, period, totalStudents, completedStudents, attachments));
            }

            try
            {
                var dto = new SubmitReportDto
                {
                    Title = title,
                    Content = content,
                    Period = period,
                    TotalStudents = totalStudents,
                    CompletedStudents = completedStudents,
                    Attachments = attachments
                };

                var response = await _repository.SubmitReportAsync(dto);
                return (response.Success, response.Message ?? "Failed");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        // Get topics
        public async Task<(bool Success, string Message, List<InternshipTopic> Data)> GetTopicsAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetTopics());
            }

            try
            {
                var response = await _repository.GetTopicsAsync();
                if (response.Success)
                {
                    var topics = response.Topics.Select(MapToInternshipTopic).ToList();
                    return (true, response.Message ?? "Success", topics);
                }
                return (false, response.Message ?? "Failed", new List<InternshipTopic>());
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", new List<InternshipTopic>());
            }
        }

        // Create topic
        public async Task<(bool Success, string Message)> CreateTopicAsync(string title, string description, string requirements, int maxStudents, string duration, string location, string supervisor)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.CreateTopic(title, description, requirements, maxStudents, duration, location, supervisor));
            }

            try
            {
                var dto = new CreateTopicDto
                {
                    Title = title,
                    Description = description,
                    Requirements = requirements,
                    MaxStudents = maxStudents,
                    Duration = duration,
                    Location = location,
                    Supervisor = supervisor
                };

                var response = await _repository.CreateTopicAsync(dto);
                return (response.Success, response.Message ?? "Failed");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        // Update topic
        public async Task<(bool Success, string Message)> UpdateTopicAsync(string topicId, string title, string description, string requirements, int maxStudents, string duration, string location, string supervisor)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.UpdateTopic(topicId, title, description, requirements, maxStudents, duration, location, supervisor));
            }

            try
            {
                var dto = new CreateTopicDto
                {
                    Title = title,
                    Description = description,
                    Requirements = requirements,
                    MaxStudents = maxStudents,
                    Duration = duration,
                    Location = location,
                    Supervisor = supervisor
                };

                var response = await _repository.UpdateTopicAsync(topicId, dto);
                return (response.Success, response.Message ?? "Failed");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        // Delete topic
        public async Task<(bool Success, string Message)> DeleteTopicAsync(string topicId)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.DeleteTopic(topicId));
            }

            try
            {
                var response = await _repository.DeleteTopicAsync(topicId);
                return (response.Success, response.Message ?? "Failed");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        // Get statistics
        public async Task<(bool Success, string Message, CompanyStatistics? Data)> GetStatisticsAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetStatistics());
            }

            // TODO: Implement API call when backend is ready
            return (false, "API not implemented yet", null);
        }

        // Mapping methods
        private StudentConfirmation MapToStudentConfirmation(StudentConfirmationDto dto)
        {
            return new StudentConfirmation
            {
                Id = dto.Id,
                StudentId = dto.StudentId,
                StudentCode = dto.StudentCode,
                StudentName = dto.StudentName,
                Email = dto.Email,
                Phone = dto.Phone,
                TopicTitle = dto.TopicTitle,
                Supervisor = dto.Supervisor,
                Status = dto.Status,
                RequestedAt = dto.RequestedAt,
                ConfirmedAt = dto.ConfirmedAt,
                Notes = dto.Notes
            };
        }

        private StudentEvaluation MapToStudentEvaluation(StudentEvaluationDto dto)
        {
            return new StudentEvaluation
            {
                Id = dto.Id,
                StudentId = dto.StudentId,
                StudentCode = dto.StudentCode,
                StudentName = dto.StudentName,
                TopicTitle = dto.TopicTitle,
                AttendanceScore = dto.AttendanceScore,
                AttitudeScore = dto.AttitudeScore,
                SkillScore = dto.SkillScore,
                ResultScore = dto.ResultScore,
                TotalScore = dto.TotalScore,
                Comment = dto.Comment,
                Status = dto.Status,
                EvaluatedAt = dto.EvaluatedAt
            };
        }

        private CompanyReport MapToCompanyReport(CompanyReportDto dto)
        {
            return new CompanyReport
            {
                Id = dto.Id,
                CompanyId = dto.CompanyId,
                Title = dto.Title,
                Content = dto.Content,
                Period = dto.Period,
                TotalStudents = dto.TotalStudents,
                CompletedStudents = dto.CompletedStudents,
                Attachments = dto.Attachments,
                Status = dto.Status,
                CreatedAt = dto.CreatedAt,
                SubmittedAt = dto.SubmittedAt
            };
        }

        private InternshipTopic MapToInternshipTopic(CompanyInternshipTopicDto dto)
        {
            return new InternshipTopic
            {
                Id = dto.Id,
                CompanyId = dto.CompanyId,
                Title = dto.Title,
                Description = dto.Description,
                Requirements = dto.Requirements,
                MaxStudents = dto.MaxStudents,
                CurrentStudents = dto.CurrentStudents,
                Duration = dto.Duration,
                Location = dto.Location,
                Supervisor = dto.Supervisor,
                Status = dto.Status,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };
        }
    }
}

