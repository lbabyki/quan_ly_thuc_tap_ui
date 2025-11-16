using System;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model cho nhật ký hệ thống
    /// </summary>
    public class SystemLog
    {
        public string? Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string ActionType { get; set; } = string.Empty; // create, update, delete, login, logout
        public string TargetType { get; set; } = string.Empty; // user, student, company, internship, etc.
        public string? TargetId { get; set; }
        public string? Details { get; set; }
        public string IpAddress { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}

