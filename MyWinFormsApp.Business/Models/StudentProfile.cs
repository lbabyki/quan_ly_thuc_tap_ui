using System;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model cho hồ sơ sinh viên
    /// </summary>
    public class StudentProfile
    {
        public string? Id { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Department { get; set; }
        public int Year { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Description { get; set; }
        public string? CvUrl { get; set; }
        public string Status { get; set; } = "pending"; // pending, approved, rejected
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// Model cho đăng ký thực tập
    /// </summary>
    public class InternshipRegistration
    {
        public string? Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string TopicId { get; set; } = string.Empty;
        public string TopicTitle { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string? CoverLetterUrl { get; set; }
        public string Status { get; set; } = "pending"; // pending, approved, rejected
        public string? RejectionReason { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
    }

    /// <summary>
    /// Model cho báo cáo tuần
    /// </summary>
    public class WeeklyReport
    {
        public string? Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public int WeekNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? AttachmentUrl { get; set; }
        public int Progress { get; set; } // 0-100
        public string Status { get; set; } = "draft"; // draft, submitted, reviewed
        public string? LecturerComment { get; set; }
        public string? CompanyComment { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Model cho nhật ký công việc
    /// </summary>
    public class WorkLog
    {
        public string? Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int HoursWorked { get; set; }
        public string? Tags { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Model cho điểm đánh giá
    /// </summary>
    public class StudentGrade
    {
        public string? Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // process, report, defense
        public double Score { get; set; }
        public double MaxScore { get; set; }
        public string? Comment { get; set; }
        public string GradedBy { get; set; } = string.Empty; // lecturer, company
        public string GraderName { get; set; } = string.Empty;
        public DateTime GradedAt { get; set; }
    }

    /// <summary>
    /// Model cho tiến độ thực tập
    /// </summary>
    public class InternshipProgress
    {
        public string? Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public int TotalWeeks { get; set; }
        public int CompletedWeeks { get; set; }
        public int ProgressPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReportDeadline { get; set; }
        public DateTime? DefenseDate { get; set; }
        public int DaysRemaining { get; set; }
        public string Status { get; set; } = "in_progress"; // not_started, in_progress, completed
    }

    /// <summary>
    /// Model cho milestone
    /// </summary>
    public class Milestone
    {
        public string? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
    }

    /// <summary>
    /// Model cho thống kê sinh viên
    /// </summary>
    public class StudentStatistics
    {
        public int TotalReports { get; set; }
        public int SubmittedReports { get; set; }
        public int TotalWorkLogs { get; set; }
        public int TotalHoursWorked { get; set; }
        public double AverageScore { get; set; }
        public int DaysRemaining { get; set; }
        public int CompletedMilestones { get; set; }
        public int TotalMilestones { get; set; }
    }
}

