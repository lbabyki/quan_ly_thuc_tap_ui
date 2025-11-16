using System;
using System.Collections.Generic;
using MyWinFormsApp.Business.Models;

namespace MyWinFormsApp.Business.Interfaces
{
    /// <summary>
    /// Interface for Lecturer data provider (can be Mock or API)
    /// </summary>
    public interface ILecturerDataProvider
    {
        // Profile
        (bool Success, string Message, LecturerProfile? Data) GetProfile();

        // Supervised Students
        (bool Success, string Message, List<SupervisedStudent> Data) GetSupervisedStudents(string? status = null);

        // Reports
        (bool Success, string Message, List<StudentReport> Data) GetStudentReports(string? studentId = null, string? status = null);
        (bool Success, string Message) ReviewReport(string reportId, string comment);

        // Grading
        (bool Success, string Message, List<StudentGrading> Data) GetStudentGradings();
        (bool Success, string Message) SubmitGrade(string studentId, decimal processScore, decimal reportScore, decimal defenseScore, string? comment);

        // Defense Schedule
        (bool Success, string Message, List<DefenseSchedule> Data) GetDefenseSchedules();
        (bool Success, string Message, DefenseSchedule? Data) CreateDefenseSchedule(string studentId, DateTime defenseDate, string location, string? councilMembers, string? notes);

        // Statistics
        (bool Success, string Message, LecturerStatistics? Data) GetStatistics();
    }
}

