using System;
using System.Collections.Generic;
using MyWinFormsApp.Business.Interfaces;
using MyWinFormsApp.Business.Models;
using MyWinFormsApp.MockData;

namespace MyWinFormsApp.UI.Services
{
    /// <summary>
    /// Mock data provider wrapper for Teacher module
    /// Implements ILecturerDataProvider by delegating to TeacherMockData
    /// </summary>
    public class TeacherMockDataProvider : ILecturerDataProvider
    {
        public (bool Success, string Message, LecturerProfile? Data) GetProfile()
        {
            return TeacherMockData.GetProfile();
        }

        public (bool Success, string Message, List<SupervisedStudent> Data) GetSupervisedStudents(string? status = null)
        {
            return TeacherMockData.GetSupervisedStudents(status);
        }

        public (bool Success, string Message, List<StudentReport> Data) GetStudentReports(string? studentId = null, string? status = null)
        {
            return TeacherMockData.GetStudentReports(studentId, status);
        }

        public (bool Success, string Message) ReviewReport(string reportId, string comment)
        {
            return TeacherMockData.ReviewReport(reportId, comment);
        }

        public (bool Success, string Message, List<StudentGrading> Data) GetStudentGradings()
        {
            return TeacherMockData.GetStudentGradings();
        }

        public (bool Success, string Message) SubmitGrade(string studentId, decimal processScore, decimal reportScore, decimal defenseScore, string? comment)
        {
            return TeacherMockData.SubmitGrade(studentId, processScore, reportScore, defenseScore, comment);
        }

        public (bool Success, string Message, List<DefenseSchedule> Data) GetDefenseSchedules()
        {
            return TeacherMockData.GetDefenseSchedules();
        }

        public (bool Success, string Message, DefenseSchedule? Data) CreateDefenseSchedule(string studentId, DateTime defenseDate, string location, string? councilMembers, string? notes)
        {
            return TeacherMockData.CreateDefenseSchedule(studentId, defenseDate, location, councilMembers, notes);
        }

        public (bool Success, string Message, LecturerStatistics? Data) GetStatistics()
        {
            return TeacherMockData.GetStatistics();
        }
    }
}

