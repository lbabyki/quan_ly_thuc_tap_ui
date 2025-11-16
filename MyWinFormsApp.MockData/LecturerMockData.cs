using MyWinFormsApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWinFormsApp.MockData
{
    /// <summary>
    /// Mock data cho Lecturer module
    /// </summary>
    public static class LecturerMockData
    {
        private static List<Lecturer> _lecturers = new List<Lecturer>();

        static LecturerMockData()
        {
            InitializeLecturers();
        }

        public static List<Lecturer> GetAllLecturers()
        {
            return _lecturers.ToList();
        }

        public static Lecturer? GetLecturerById(string id)
        {
            return _lecturers.FirstOrDefault(l => l.Id == id);
        }

        public static (bool Success, string Message, Lecturer? Lecturer) CreateLecturer(Lecturer lecturer)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(lecturer.Email))
            {
                return (false, "Email không được để trống", null);
            }

            if (_lecturers.Any(l => l.Email.Equals(lecturer.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return (false, "Email đã tồn tại", null);
            }

            if (string.IsNullOrWhiteSpace(lecturer.FullName))
            {
                return (false, "Họ tên không được để trống", null);
            }

            // Create
            lecturer.Id = Guid.NewGuid().ToString();
            lecturer.Role = "lecturer";
            lecturer.CreatedAt = DateTime.Now;
            lecturer.UpdatedAt = DateTime.Now;

            _lecturers.Add(lecturer);

            return (true, "Tạo giảng viên thành công", lecturer);
        }

        public static (bool Success, string Message, Lecturer? Lecturer) UpdateLecturer(string id, Lecturer lecturer)
        {
            var existing = _lecturers.FirstOrDefault(l => l.Id == id);
            if (existing == null)
            {
                return (false, "Không tìm thấy giảng viên", null);
            }

            // Validate
            if (string.IsNullOrWhiteSpace(lecturer.Email))
            {
                return (false, "Email không được để trống", null);
            }

            // Check email duplicate (except current lecturer)
            if (_lecturers.Any(l => l.Id != id && l.Email.Equals(lecturer.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return (false, "Email đã tồn tại", null);
            }

            // Update
            existing.UserName = lecturer.UserName;
            existing.FullName = lecturer.FullName;
            existing.Email = lecturer.Email;
            existing.Phone = lecturer.Phone;
            existing.Department = lecturer.Department;
            existing.Specialization = lecturer.Specialization;
            existing.UpdatedAt = DateTime.Now;

            return (true, "Cập nhật giảng viên thành công", existing);
        }

        public static (bool Success, string Message) DeleteLecturer(string id)
        {
            var lecturer = _lecturers.FirstOrDefault(l => l.Id == id);
            if (lecturer == null)
            {
                return (false, "Không tìm thấy giảng viên");
            }

            _lecturers.Remove(lecturer);
            return (true, "Xóa giảng viên thành công");
        }

        public static (bool Success, string Message) ResetPassword(string id, string newPassword = "123456")
        {
            var lecturer = _lecturers.FirstOrDefault(l => l.Id == id);
            if (lecturer == null)
            {
                return (false, "Không tìm thấy giảng viên");
            }

            lecturer.Password = newPassword;
            lecturer.UpdatedAt = DateTime.Now;
            return (true, $"Reset mật khẩu thành công cho giảng viên {lecturer.FullName}. Mật khẩu mới: {newPassword}");
        }

        private static void InitializeLecturers()
        {
            _lecturers = new List<Lecturer>
            {
                new Lecturer
                {
                    Id = "lecturer001",
                    UserName = "nguyenvanc",
                    FullName = "TS. Nguyễn Văn C",
                    Email = "nguyenvanc@lhu.edu.vn",
                    Phone = "0934567890",
                    Department = "Công nghệ thông tin",
                    Specialization = "Công nghệ phần mềm",
                    AssignedStudents = new List<string> { "student001", "student002" },
                    Password = "123456",
                    CreatedAt = DateTime.Now.AddYears(-2),
                    UpdatedAt = DateTime.Now.AddMonths(-1)
                },
                new Lecturer
                {
                    Id = "lecturer002",
                    UserName = "tranthid",
                    FullName = "PGS.TS. Trần Thị D",
                    Email = "tranthid@lhu.edu.vn",
                    Phone = "0945678901",
                    Department = "Kỹ thuật phần mềm",
                    Specialization = "Trí tuệ nhân tạo",
                    AssignedStudents = new List<string> { "student003" },
                    Password = "123456",
                    CreatedAt = DateTime.Now.AddYears(-3),
                    UpdatedAt = DateTime.Now.AddMonths(-2)
                }
            };
        }
    }
}

