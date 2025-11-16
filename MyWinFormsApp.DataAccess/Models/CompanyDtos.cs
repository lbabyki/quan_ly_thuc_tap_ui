using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyWinFormsApp.DataAccess.Models
{
    /// <summary>
    /// DTO cho xác nhận sinh viên
    /// </summary>
    public class ConfirmStudentDto
    {
        [JsonProperty("student_id")]
        public string StudentId { get; set; } = string.Empty;

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty; // confirmed, rejected

        [JsonProperty("supervisor")]
        public string? Supervisor { get; set; }

        [JsonProperty("notes")]
        public string? Notes { get; set; }
    }

    /// <summary>
    /// DTO cho đánh giá sinh viên
    /// </summary>
    public class SubmitEvaluationDto
    {
        [JsonProperty("student_id")]
        public string StudentId { get; set; } = string.Empty;

        [JsonProperty("attendance_score")]
        public decimal AttendanceScore { get; set; }

        [JsonProperty("attitude_score")]
        public decimal AttitudeScore { get; set; }

        [JsonProperty("skill_score")]
        public decimal SkillScore { get; set; }

        [JsonProperty("result_score")]
        public decimal ResultScore { get; set; }

        [JsonProperty("comment")]
        public string? Comment { get; set; }
    }

    /// <summary>
    /// DTO cho tạo/cập nhật báo cáo
    /// </summary>
    public class SubmitReportDto
    {
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("content")]
        public string Content { get; set; } = string.Empty;

        [JsonProperty("period")]
        public string Period { get; set; } = string.Empty;

        [JsonProperty("total_students")]
        public int TotalStudents { get; set; }

        [JsonProperty("completed_students")]
        public int CompletedStudents { get; set; }

        [JsonProperty("attachments")]
        public List<string> Attachments { get; set; } = new List<string>();
    }

    /// <summary>
    /// DTO cho tạo/cập nhật đề tài
    /// </summary>
    public class CreateTopicDto
    {
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("requirements")]
        public string Requirements { get; set; } = string.Empty;

        [JsonProperty("max_students")]
        public int MaxStudents { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; } = string.Empty;

        [JsonProperty("location")]
        public string Location { get; set; } = string.Empty;

        [JsonProperty("supervisor")]
        public string Supervisor { get; set; } = string.Empty;
    }

    /// <summary>
    /// Response cho danh sách sinh viên chờ xác nhận
    /// </summary>
    public class StudentConfirmationsResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("confirmations")]
        public List<StudentConfirmationDto> Confirmations { get; set; } = new List<StudentConfirmationDto>();
    }

    public class StudentConfirmationDto
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("student_id")]
        public string StudentId { get; set; } = string.Empty;

        [JsonProperty("student_code")]
        public string StudentCode { get; set; } = string.Empty;

        [JsonProperty("student_name")]
        public string StudentName { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonProperty("topic_title")]
        public string TopicTitle { get; set; } = string.Empty;

        [JsonProperty("supervisor")]
        public string Supervisor { get; set; } = string.Empty;

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("requested_at")]
        public DateTime RequestedAt { get; set; }

        [JsonProperty("confirmed_at")]
        public DateTime? ConfirmedAt { get; set; }

        [JsonProperty("notes")]
        public string? Notes { get; set; }
    }

    /// <summary>
    /// Response cho danh sách đánh giá
    /// </summary>
    public class StudentEvaluationsResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("evaluations")]
        public List<StudentEvaluationDto> Evaluations { get; set; } = new List<StudentEvaluationDto>();
    }

    public class StudentEvaluationDto
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("student_id")]
        public string StudentId { get; set; } = string.Empty;

        [JsonProperty("student_code")]
        public string StudentCode { get; set; } = string.Empty;

        [JsonProperty("student_name")]
        public string StudentName { get; set; } = string.Empty;

        [JsonProperty("topic_title")]
        public string TopicTitle { get; set; } = string.Empty;

        [JsonProperty("attendance_score")]
        public decimal? AttendanceScore { get; set; }

        [JsonProperty("attitude_score")]
        public decimal? AttitudeScore { get; set; }

        [JsonProperty("skill_score")]
        public decimal? SkillScore { get; set; }

        [JsonProperty("result_score")]
        public decimal? ResultScore { get; set; }

        [JsonProperty("total_score")]
        public decimal? TotalScore { get; set; }

        [JsonProperty("comment")]
        public string? Comment { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("evaluated_at")]
        public DateTime? EvaluatedAt { get; set; }
    }

    /// <summary>
    /// Response cho danh sách báo cáo
    /// </summary>
    public class CompanyReportsResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("reports")]
        public List<CompanyReportDto> Reports { get; set; } = new List<CompanyReportDto>();
    }

    public class CompanyReportDto
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("company_id")]
        public string CompanyId { get; set; } = string.Empty;

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("content")]
        public string Content { get; set; } = string.Empty;

        [JsonProperty("period")]
        public string Period { get; set; } = string.Empty;

        [JsonProperty("total_students")]
        public int TotalStudents { get; set; }

        [JsonProperty("completed_students")]
        public int CompletedStudents { get; set; }

        [JsonProperty("attachments")]
        public List<string> Attachments { get; set; } = new List<string>();

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("submitted_at")]
        public DateTime? SubmittedAt { get; set; }
    }

    /// <summary>
    /// Response cho danh sách đề tài
    /// </summary>
    public class InternshipTopicsResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("topics")]
        public List<CompanyInternshipTopicDto> Topics { get; set; } = new List<CompanyInternshipTopicDto>();
    }

    public class CompanyInternshipTopicDto
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("company_id")]
        public string CompanyId { get; set; } = string.Empty;

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("requirements")]
        public string Requirements { get; set; } = string.Empty;

        [JsonProperty("max_students")]
        public int MaxStudents { get; set; }

        [JsonProperty("current_students")]
        public int CurrentStudents { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; } = string.Empty;

        [JsonProperty("location")]
        public string Location { get; set; } = string.Empty;

        [JsonProperty("supervisor")]
        public string Supervisor { get; set; } = string.Empty;

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}

