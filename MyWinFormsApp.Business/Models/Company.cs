using System;
using System.Collections.Generic;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model đại diện cho Company (Công ty)
    /// </summary>
    public class Company
    {
        public string? Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string ContactPerson { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string? ContactPhone { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "company";
        public List<string> InternshipPositions { get; set; } = new List<string>(); // ObjectId references
        public List<string> CurrentStudents { get; set; } = new List<string>(); // ObjectId references
        public string Status { get; set; } = "active"; // active, inactive
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

