using System;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model đại diện cho User trong hệ thống
    /// </summary>
    public class User
    {
        public string? UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // student, lecturer, company, admin
        public string? Token { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Phone { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

