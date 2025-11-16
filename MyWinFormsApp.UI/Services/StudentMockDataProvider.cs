using System;
using System.Collections.Generic;
using MyWinFormsApp.Business.Interfaces;
using MyWinFormsApp.Business.Models;
using MyWinFormsApp.MockData;

namespace MyWinFormsApp.UI.Services
{
    /// <summary>
    /// Mock data provider implementation for Student module
    /// This class wraps StudentProfileMockData to implement IStudentDataProvider
    /// </summary>
    public class StudentMockDataProvider : IStudentDataProvider
    {
        public (bool Success, string Message, StudentProfile? Data) GetProfile()
        {
            return StudentProfileMockData.GetProfile();
        }

        public (bool Success, string Message) UpdateProfile(string phone, string description, string? avatarUrl, string? cvUrl)
        {
            return StudentProfileMockData.UpdateProfile(phone, description, avatarUrl, cvUrl);
        }

        public (bool Success, string Message, List<InternshipTopic> Data) GetAvailableTopics()
        {
            return StudentProfileMockData.GetAvailableTopics();
        }

        public (bool Success, string Message, InternshipRegistration? Data) RegisterInternship(int topicId, string coverLetter, string? coverLetterUrl)
        {
            return StudentProfileMockData.RegisterInternship(topicId, coverLetter, coverLetterUrl);
        }

        public (bool Success, string Message, List<InternshipRegistration> Data) GetMyRegistrations()
        {
            return StudentProfileMockData.GetMyRegistrations();
        }

        public (bool Success, string Message, List<WeeklyReport> Data) GetWeeklyReports()
        {
            return StudentProfileMockData.GetWeeklyReports();
        }

        public (bool Success, string Message, WeeklyReport? Data) CreateWeeklyReport(int weekNumber, string title, string content, int progress)
        {
            return StudentProfileMockData.CreateWeeklyReport(weekNumber, title, content, progress);
        }

        public (bool Success, string Message) SubmitWeeklyReport(int reportId)
        {
            return StudentProfileMockData.SubmitWeeklyReport(reportId.ToString());
        }

        public (bool Success, string Message, List<WorkLog> Data) GetWorkLogs()
        {
            return StudentProfileMockData.GetWorkLogs();
        }

        public (bool Success, string Message, WorkLog? Data) CreateWorkLog(DateTime date, string title, string content, decimal hoursWorked, string? tags)
        {
            return StudentProfileMockData.CreateWorkLog(date, title, content, (int)hoursWorked, tags);
        }

        public (bool Success, string Message, List<StudentGrade> Data) GetGrades()
        {
            return StudentProfileMockData.GetGrades();
        }

        public (bool Success, string Message, InternshipProgress? Data) GetProgress()
        {
            return StudentProfileMockData.GetProgress();
        }

        public (bool Success, string Message, StudentStatistics? Data) GetStatistics()
        {
            return StudentProfileMockData.GetStatistics();
        }

        public (bool Success, string Message, List<Milestone> Data) GetMilestones()
        {
            return StudentProfileMockData.GetMilestones();
        }
    }
}

