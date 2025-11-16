using System;
using System.Collections.Generic;

namespace MyWinFormsApp.DataAccess.Models
{
    /// <summary>
    /// DTO cho cập nhật hồ sơ sinh viên
    /// </summary>
    public class UpdateStudentProfileDto
    {
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public string? AvatarUrl { get; set; }
        public string? CvUrl { get; set; }
    }

    /// <summary>
    /// DTO cho đăng ký thực tập
    /// </summary>
    public class CreateInternshipRegistrationDto
    {
        public string TopicId { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
        public string? CoverLetterUrl { get; set; }
    }

    /// <summary>
    /// DTO cho tạo báo cáo tuần
    /// </summary>
    public class CreateWeeklyReportDto
    {
        public int WeekNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? AttachmentUrl { get; set; }
        public int Progress { get; set; }
    }

    /// <summary>
    /// DTO cho cập nhật báo cáo tuần
    /// </summary>
    public class UpdateWeeklyReportDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? AttachmentUrl { get; set; }
        public int Progress { get; set; }
    }

    /// <summary>
    /// DTO cho tạo nhật ký công việc
    /// </summary>
    public class CreateWorkLogDto
    {
        public DateTime Date { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int HoursWorked { get; set; }
        public string? Tags { get; set; }
    }

    /// <summary>
    /// Response cho danh sách đề tài
    /// </summary>
    public class AvailableTopicsResponse
    {
        public List<TopicDto> Topics { get; set; } = new List<TopicDto>();
    }

    public class TopicDto
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public int MaxStudents { get; set; }
        public int RegisteredStudents { get; set; }
        public string Requirements { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    /// <summary>
    /// Response cho tiến độ
    /// </summary>
    public class ProgressResponse
    {
        public int TotalWeeks { get; set; }
        public int CompletedWeeks { get; set; }
        public int ProgressPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReportDeadline { get; set; }
        public DateTime? DefenseDate { get; set; }
        public int DaysRemaining { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    /// <summary>
    /// Response cho điểm
    /// </summary>
    public class GradesResponse
    {
        public List<GradeDto> Grades { get; set; } = new List<GradeDto>();
        public double AverageScore { get; set; }
    }

    public class GradeDto
    {
        public string Id { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public double Score { get; set; }
        public double MaxScore { get; set; }
        public string? Comment { get; set; }
        public string GradedBy { get; set; } = string.Empty;
        public string GraderName { get; set; } = string.Empty;
        public DateTime GradedAt { get; set; }
    }

    /// <summary>
    /// Response cho thống kê
    /// </summary>
    public class StatisticsResponse
    {
        public int TotalReports { get; set; }
        public int SubmittedReports { get; set; }
        public int TotalWorkLogs { get; set; }
        public int TotalHoursWorked { get; set; }
        public double AverageScore { get; set; }
        public int DaysRemaining { get; set; }
        public int CompletedMilestones { get; set; }
        public int TotalMilestones { get; set; }
        public List<MilestoneDto> Milestones { get; set; } = new List<MilestoneDto>();
    }

    public class MilestoneDto
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}

