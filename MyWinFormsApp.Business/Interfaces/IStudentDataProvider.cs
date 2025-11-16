using System.Collections.Generic;
using MyWinFormsApp.Business.Models;

namespace MyWinFormsApp.Business.Interfaces
{
    /// <summary>
    /// Interface for Student data provider (can be Mock or API)
    /// </summary>
    public interface IStudentDataProvider
    {
        // Profile
        (bool Success, string Message, StudentProfile? Data) GetProfile();
        (bool Success, string Message) UpdateProfile(string phone, string description, string? avatarUrl, string? cvUrl);

        // Registration
        (bool Success, string Message, List<InternshipTopic> Data) GetAvailableTopics();
        (bool Success, string Message, InternshipRegistration? Data) RegisterInternship(int topicId, string coverLetter, string? coverLetterUrl);
        (bool Success, string Message, List<InternshipRegistration> Data) GetMyRegistrations();

        // Weekly Reports
        (bool Success, string Message, List<WeeklyReport> Data) GetWeeklyReports();
        (bool Success, string Message, WeeklyReport? Data) CreateWeeklyReport(int weekNumber, string title, string content, int progress);
        (bool Success, string Message) SubmitWeeklyReport(int reportId);

        // Work Logs
        (bool Success, string Message, List<WorkLog> Data) GetWorkLogs();
        (bool Success, string Message, WorkLog? Data) CreateWorkLog(DateTime date, string title, string content, decimal hoursWorked, string? tags);

        // Grades
        (bool Success, string Message, List<StudentGrade> Data) GetGrades();

        // Progress
        (bool Success, string Message, InternshipProgress? Data) GetProgress();

        // Statistics
        (bool Success, string Message, StudentStatistics? Data) GetStatistics();
        (bool Success, string Message, List<Milestone> Data) GetMilestones();
    }
}

