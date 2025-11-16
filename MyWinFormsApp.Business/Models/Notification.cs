using System;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model cho Thông báo hệ thống
    /// </summary>
    public class Notification
    {
        public string? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Type { get; set; } = "info"; // info, warning, success, error
        public string TargetType { get; set; } = "all"; // all, student, lecturer, company, specific
        public List<string> TargetUserIds { get; set; } = new List<string>();
        public string? SenderId { get; set; }
        public string? SenderName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ScheduledAt { get; set; }
        public bool IsSent { get; set; } = false;
        public DateTime? SentAt { get; set; }
        public int TotalRecipients { get; set; } = 0;
        public int SuccessCount { get; set; } = 0;
        public int FailureCount { get; set; } = 0;
        public string? Notes { get; set; }
    }
}

