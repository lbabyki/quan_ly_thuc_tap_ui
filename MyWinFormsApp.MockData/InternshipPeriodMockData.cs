using MyWinFormsApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWinFormsApp.MockData
{
    /// <summary>
    /// Mock data cho Internship Period module
    /// </summary>
    public static class InternshipPeriodMockData
    {
        private static List<InternshipPeriod> _periods = new List<InternshipPeriod>();

        static InternshipPeriodMockData()
        {
            InitializePeriods();
        }

        public static List<InternshipPeriod> GetAllPeriods()
        {
            return _periods.OrderByDescending(p => p.CreatedAt).ToList();
        }

        public static InternshipPeriod? GetPeriodById(string id)
        {
            return _periods.FirstOrDefault(p => p.Id == id);
        }

        public static List<InternshipPeriod> GetPeriodsByStatus(string status)
        {
            return _periods.Where(p => p.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                          .OrderByDescending(p => p.CreatedAt)
                          .ToList();
        }

        public static (bool Success, string Message, InternshipPeriod? Period) CreatePeriod(InternshipPeriod period)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(period.Name))
            {
                return (false, "Tên kỳ thực tập không được để trống", null);
            }

            if (string.IsNullOrWhiteSpace(period.AcademicYear))
            {
                return (false, "Năm học không được để trống", null);
            }

            if (period.Semester < 1 || period.Semester > 3)
            {
                return (false, "Học kỳ phải từ 1 đến 3", null);
            }

            if (period.StartDate >= period.EndDate)
            {
                return (false, "Ngày bắt đầu phải trước ngày kết thúc", null);
            }

            if (period.RegistrationDeadline >= period.StartDate)
            {
                return (false, "Hạn đăng ký phải trước ngày bắt đầu", null);
            }

            if (period.ReportDeadline <= period.StartDate || period.ReportDeadline > period.EndDate)
            {
                return (false, "Hạn nộp báo cáo phải trong khoảng thời gian thực tập", null);
            }

            // Check duplicate
            if (_periods.Any(p => p.Name.Equals(period.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return (false, "Tên kỳ thực tập đã tồn tại", null);
            }

            // Create
            period.Id = Guid.NewGuid().ToString();
            period.Status = "draft";
            period.RegisteredStudents = 0;
            period.TotalTopics = 0;
            period.CreatedAt = DateTime.Now;
            period.UpdatedAt = DateTime.Now;

            _periods.Add(period);

            return (true, "Tạo kỳ thực tập thành công", period);
        }

        public static (bool Success, string Message, InternshipPeriod? Period) UpdatePeriod(string id, InternshipPeriod period)
        {
            var existing = _periods.FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {
                return (false, "Không tìm thấy kỳ thực tập", null);
            }

            // Validate
            if (string.IsNullOrWhiteSpace(period.Name))
            {
                return (false, "Tên kỳ thực tập không được để trống", null);
            }

            if (period.StartDate >= period.EndDate)
            {
                return (false, "Ngày bắt đầu phải trước ngày kết thúc", null);
            }

            // Check duplicate name (except current)
            if (_periods.Any(p => p.Id != id && p.Name.Equals(period.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return (false, "Tên kỳ thực tập đã tồn tại", null);
            }

            // Update
            existing.Name = period.Name;
            existing.Description = period.Description;
            existing.Semester = period.Semester;
            existing.AcademicYear = period.AcademicYear;
            existing.StartDate = period.StartDate;
            existing.EndDate = period.EndDate;
            existing.RegistrationDeadline = period.RegistrationDeadline;
            existing.ReportDeadline = period.ReportDeadline;
            existing.DefenseDate = period.DefenseDate;
            existing.Notes = period.Notes;
            existing.UpdatedAt = DateTime.Now;

            return (true, "Cập nhật kỳ thực tập thành công", existing);
        }

        public static (bool Success, string Message) DeletePeriod(string id)
        {
            var period = _periods.FirstOrDefault(p => p.Id == id);
            if (period == null)
            {
                return (false, "Không tìm thấy kỳ thực tập");
            }

            // Check if period is in use
            if (period.Status == "in_progress" || period.Status == "open")
            {
                return (false, "Không thể xóa kỳ thực tập đang mở hoặc đang diễn ra");
            }

            _periods.Remove(period);
            return (true, "Xóa kỳ thực tập thành công");
        }

        public static (bool Success, string Message, InternshipPeriod? Period) OpenPeriod(string id)
        {
            var period = _periods.FirstOrDefault(p => p.Id == id);
            if (period == null)
            {
                return (false, "Không tìm thấy kỳ thực tập", null);
            }

            if (period.Status != "draft")
            {
                return (false, "Chỉ có thể mở kỳ thực tập ở trạng thái nháp", null);
            }

            period.Status = "open";
            period.UpdatedAt = DateTime.Now;

            return (true, "Mở kỳ thực tập thành công", period);
        }

        public static (bool Success, string Message, InternshipPeriod? Period) ClosePeriod(string id)
        {
            var period = _periods.FirstOrDefault(p => p.Id == id);
            if (period == null)
            {
                return (false, "Không tìm thấy kỳ thực tập", null);
            }

            if (period.Status == "closed" || period.Status == "completed")
            {
                return (false, "Kỳ thực tập đã đóng", null);
            }

            period.Status = "closed";
            period.UpdatedAt = DateTime.Now;

            return (true, "Đóng kỳ thực tập thành công", period);
        }

        private static void InitializePeriods()
        {
            _periods = new List<InternshipPeriod>
            {
                new InternshipPeriod
                {
                    Id = "period001",
                    Name = "Kỳ thực tập HK1 2024-2025",
                    Description = "Kỳ thực tập học kỳ 1 năm học 2024-2025",
                    Semester = 1,
                    AcademicYear = "2024-2025",
                    StartDate = new DateTime(2024, 9, 1),
                    EndDate = new DateTime(2024, 12, 31),
                    RegistrationDeadline = new DateTime(2024, 8, 15),
                    ReportDeadline = new DateTime(2024, 12, 20),
                    DefenseDate = new DateTime(2024, 12, 28),
                    Status = "completed",
                    RegisteredStudents = 45,
                    TotalTopics = 20,
                    Notes = "Kỳ thực tập đầu tiên của năm học",
                    CreatedBy = "admin@lhu.edu.vn",
                    CreatedAt = new DateTime(2024, 7, 1),
                    UpdatedAt = new DateTime(2024, 12, 31)
                },
                new InternshipPeriod
                {
                    Id = "period002",
                    Name = "Kỳ thực tập HK2 2024-2025",
                    Description = "Kỳ thực tập học kỳ 2 năm học 2024-2025",
                    Semester = 2,
                    AcademicYear = "2024-2025",
                    StartDate = new DateTime(2025, 1, 15),
                    EndDate = new DateTime(2025, 5, 31),
                    RegistrationDeadline = new DateTime(2025, 1, 5),
                    ReportDeadline = new DateTime(2025, 5, 20),
                    DefenseDate = new DateTime(2025, 5, 28),
                    Status = "in_progress",
                    RegisteredStudents = 52,
                    TotalTopics = 25,
                    Notes = "Kỳ thực tập đang diễn ra",
                    CreatedBy = "admin@lhu.edu.vn",
                    CreatedAt = new DateTime(2024, 11, 1),
                    UpdatedAt = new DateTime(2025, 1, 15)
                },
                new InternshipPeriod
                {
                    Id = "period003",
                    Name = "Kỳ thực tập Hè 2025",
                    Description = "Kỳ thực tập hè năm 2025",
                    Semester = 3,
                    AcademicYear = "2024-2025",
                    StartDate = new DateTime(2025, 6, 1),
                    EndDate = new DateTime(2025, 8, 31),
                    RegistrationDeadline = new DateTime(2025, 5, 15),
                    ReportDeadline = new DateTime(2025, 8, 20),
                    DefenseDate = new DateTime(2025, 8, 28),
                    Status = "open",
                    RegisteredStudents = 15,
                    TotalTopics = 18,
                    Notes = "Kỳ thực tập hè, đang mở đăng ký",
                    CreatedBy = "admin@lhu.edu.vn",
                    CreatedAt = new DateTime(2025, 4, 1),
                    UpdatedAt = new DateTime(2025, 5, 1)
                },
                new InternshipPeriod
                {
                    Id = "period004",
                    Name = "Kỳ thực tập HK1 2025-2026",
                    Description = "Kỳ thực tập học kỳ 1 năm học 2025-2026",
                    Semester = 1,
                    AcademicYear = "2025-2026",
                    StartDate = new DateTime(2025, 9, 1),
                    EndDate = new DateTime(2025, 12, 31),
                    RegistrationDeadline = new DateTime(2025, 8, 15),
                    ReportDeadline = new DateTime(2025, 12, 20),
                    DefenseDate = new DateTime(2025, 12, 28),
                    Status = "draft",
                    RegisteredStudents = 0,
                    TotalTopics = 0,
                    Notes = "Kỳ thực tập đang chuẩn bị",
                    CreatedBy = "admin@lhu.edu.vn",
                    CreatedAt = DateTime.Now.AddDays(-10),
                    UpdatedAt = DateTime.Now.AddDays(-10)
                }
            };
        }
    }
}

