using System;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model cho đề tài thực tập
    /// </summary>
    public class InternshipTopic
    {
        public string? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string? LecturerId { get; set; }
        public string? LecturerName { get; set; }
        public string Status { get; set; } = "pending"; // pending, approved, rejected, in_progress, completed
        public int MaxStudents { get; set; } = 1;
        public int CurrentStudents { get; set; } = 0;
        public string Requirements { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Deadline { get; set; }
        public string? RejectionReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

