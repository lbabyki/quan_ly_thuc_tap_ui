using System;
using System.Collections.Generic;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model đại diện cho Internship (Vị trí thực tập)
    /// </summary>
    public class Internship
    {
        public string? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty; // ObjectId reference
        public string Description { get; set; } = string.Empty;
        public string? Requirements { get; set; }
        public int MaxStudents { get; set; } = 1;
        public List<string> Students { get; set; } = new List<string>(); // ObjectId references
        public string Status { get; set; } = "pending"; // pending, approved, rejected, open, closed
        public bool IsSuggested { get; set; } = false;
        public string? SuggestedBy { get; set; } // ObjectId reference
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

