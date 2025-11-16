using MyWinFormsApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWinFormsApp.MockData
{
    /// <summary>
    /// Mock data cho Student module
    /// </summary>
    public static class StudentMockData
    {
        private static List<Student> _students = new List<Student>();
        private static List<InternshipTopic> _topics = new List<InternshipTopic>();
        private static List<Company> _companies = new List<Company>();
        private static List<InternshipRegistration> _registrations = new List<InternshipRegistration>();

        static StudentMockData()
        {
            InitializeStudents();
            InitializeTopics();
            InitializeCompanies();
            InitializeRegistrations();
        }

        public static List<Student> GetAllStudents()
        {
            return _students.ToList();
        }

        public static Student? GetStudentById(string id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public static (bool Success, string Message, Student? Student) CreateStudent(Student student)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(student.Email))
            {
                return (false, "Email không được để trống", null);
            }

            if (_students.Any(s => s.Email.Equals(student.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return (false, "Email đã tồn tại", null);
            }

            if (string.IsNullOrWhiteSpace(student.StudentCode))
            {
                return (false, "Mã sinh viên không được để trống", null);
            }

            if (_students.Any(s => s.StudentCode == student.StudentCode))
            {
                return (false, "Mã sinh viên đã tồn tại", null);
            }

            // Create
            student.Id = Guid.NewGuid().ToString();
            student.Role = "student";
            student.Status = "pending";
            student.CreatedAt = DateTime.Now;
            student.UpdatedAt = DateTime.Now;

            _students.Add(student);

            return (true, "Tạo sinh viên thành công", student);
        }

        public static (bool Success, string Message, Student? Student) UpdateStudent(string id, Student student)
        {
            var existing = _students.FirstOrDefault(s => s.Id == id);
            if (existing == null)
            {
                return (false, "Không tìm thấy sinh viên", null);
            }

            // Validate
            if (string.IsNullOrWhiteSpace(student.Email))
            {
                return (false, "Email không được để trống", null);
            }

            // Check email duplicate (except current student)
            if (_students.Any(s => s.Id != id && s.Email.Equals(student.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return (false, "Email đã tồn tại", null);
            }

            // Update
            existing.UserName = student.UserName;
            existing.FullName = student.FullName;
            existing.Email = student.Email;
            existing.Phone = student.Phone;
            existing.StudentCode = student.StudentCode;
            existing.Department = student.Department;
            existing.Year = student.Year;
            existing.Status = student.Status;
            existing.Skills = student.Skills;
            existing.UpdatedAt = DateTime.Now;

            return (true, "Cập nhật sinh viên thành công", existing);
        }

        public static (bool Success, string Message) DeleteStudent(string id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return (false, "Không tìm thấy sinh viên");
            }

            _students.Remove(student);
            return (true, "Xóa sinh viên thành công");
        }

        public static (bool Success, string Message) ResetPassword(string id, string newPassword = "123456")
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return (false, "Không tìm thấy sinh viên");
            }

            student.Password = newPassword;
            student.UpdatedAt = DateTime.Now;
            return (true, $"Reset mật khẩu thành công cho sinh viên {student.FullName}. Mật khẩu mới: {newPassword}");
        }

        private static void InitializeStudents()
        {
            _students = new List<Student>
            {
                new Student
                {
                    Id = "student001",
                    UserName = "nguyenvana",
                    FullName = "Nguyễn Văn A",
                    Email = "nguyenvana@lhu.edu.vn",
                    Phone = "0912345678",
                    StudentCode = "2021600001",
                    Department = "Công nghệ thông tin",
                    Year = 4,
                    Status = "approved",
                    Skills = new List<string> { "C#", "ASP.NET", "SQL Server" },
                    Password = "123456",
                    CreatedAt = DateTime.Now.AddMonths(-6),
                    UpdatedAt = DateTime.Now.AddMonths(-1)
                },
                new Student
                {
                    Id = "student002",
                    UserName = "tranthib",
                    FullName = "Trần Thị B",
                    Email = "tranthib@lhu.edu.vn",
                    Phone = "0923456789",
                    StudentCode = "2021600002",
                    Department = "Kỹ thuật phần mềm",
                    Year = 4,
                    Status = "approved",
                    Skills = new List<string> { "Java", "Spring Boot", "MySQL" },
                    Password = "123456",
                    CreatedAt = DateTime.Now.AddMonths(-6),
                    UpdatedAt = DateTime.Now.AddMonths(-1)
                }
            };
        }

        #region Topics

        private static void InitializeTopics()
        {
            _topics = new List<InternshipTopic>
            {
                new InternshipTopic
                {
                    Id = "topic1",
                    Title = "Xây dựng hệ thống quản lý bán hàng trực tuyến",
                    Description = "Phát triển website bán hàng với các tính năng: quản lý sản phẩm, giỏ hàng, thanh toán online, quản lý đơn hàng",
                    Requirements = "C#, ASP.NET Core, SQL Server, HTML/CSS/JavaScript",
                    MaxStudents = 2,
                    CurrentStudents = 1,
                    CompanyId = "company1",
                    CompanyName = "FPT Software",
                    Duration = "3 tháng",
                    Location = "Hồ Chí Minh",
                    Supervisor = "Nguyễn Văn A",
                    Status = "active",
                    CreatedAt = DateTime.Now.AddMonths(-2)
                },
                new InternshipTopic
                {
                    Id = "topic2",
                    Title = "Phát triển ứng dụng mobile quản lý công việc",
                    Description = "Xây dựng app mobile (Android/iOS) để quản lý task, deadline, nhắc nhở công việc",
                    Requirements = "Flutter/React Native, Firebase, RESTful API",
                    MaxStudents = 2,
                    CurrentStudents = 0,
                    CompanyId = "company2",
                    CompanyName = "Viettel Software",
                    Duration = "3 tháng",
                    Location = "Hà Nội",
                    Supervisor = "Trần Thị B",
                    Status = "active",
                    CreatedAt = DateTime.Now.AddMonths(-1)
                },
                new InternshipTopic
                {
                    Id = "topic3",
                    Title = "Xây dựng hệ thống chatbot AI hỗ trợ khách hàng",
                    Description = "Phát triển chatbot sử dụng AI/ML để tự động trả lời câu hỏi khách hàng",
                    Requirements = "Python, TensorFlow/PyTorch, NLP, FastAPI",
                    MaxStudents = 1,
                    CurrentStudents = 1,
                    CompanyId = "company1",
                    CompanyName = "FPT Software",
                    Duration = "4 tháng",
                    Location = "Đà Nẵng",
                    Supervisor = "Lê Văn C",
                    Status = "active",
                    CreatedAt = DateTime.Now.AddMonths(-1)
                },
                new InternshipTopic
                {
                    Id = "topic4",
                    Title = "Phân tích dữ liệu và xây dựng dashboard báo cáo",
                    Description = "Thu thập, xử lý và trực quan hóa dữ liệu kinh doanh bằng Power BI/Tableau",
                    Requirements = "SQL, Python, Power BI/Tableau, Excel",
                    MaxStudents = 2,
                    CurrentStudents = 0,
                    CompanyId = "company3",
                    CompanyName = "TMA Solutions",
                    Duration = "3 tháng",
                    Location = "Hồ Chí Minh",
                    Supervisor = "Phạm Thị D",
                    Status = "active",
                    CreatedAt = DateTime.Now.AddDays(-20)
                }
            };
        }

        public static List<InternshipTopic> GetAllTopics()
        {
            return _topics.ToList();
        }

        public static List<InternshipTopic> GetAvailableTopics()
        {
            return _topics.Where(t => t.Status == "active" && t.CurrentStudents < t.MaxStudents).ToList();
        }

        #endregion

        #region Companies

        private static void InitializeCompanies()
        {
            _companies = new List<Company>
            {
                new Company
                {
                    Id = "company1",
                    CompanyName = "FPT Software",
                    ContactEmail = "contact@fpt-software.com",
                    ContactPhone = "0281234567",
                    ContactPerson = "Nguyễn Văn A",
                    Address = "Tòa nhà FPT, Quận 9, TP.HCM",
                    Status = "active",
                    CreatedAt = DateTime.Now.AddYears(-2)
                },
                new Company
                {
                    Id = "company2",
                    CompanyName = "Viettel Software",
                    ContactEmail = "contact@viettel-software.com",
                    ContactPhone = "0241234567",
                    ContactPerson = "Trần Thị B",
                    Address = "Tòa nhà Viettel, Hà Nội",
                    Status = "active",
                    CreatedAt = DateTime.Now.AddYears(-1)
                },
                new Company
                {
                    Id = "company3",
                    CompanyName = "TMA Solutions",
                    ContactEmail = "contact@tma.com.vn",
                    ContactPhone = "0281234568",
                    ContactPerson = "Lê Văn C",
                    Address = "Tòa nhà TMA, Quận 12, TP.HCM",
                    Status = "active",
                    CreatedAt = DateTime.Now.AddYears(-3)
                }
            };
        }

        public static List<Company> GetAllCompanies()
        {
            return _companies.ToList();
        }

        public static List<Company> GetApprovedCompanies()
        {
            return _companies.Where(c => c.Status == "approved").ToList();
        }

        #endregion

        #region Registrations

        private static void InitializeRegistrations()
        {
            _registrations = new List<InternshipRegistration>
            {
                new InternshipRegistration
                {
                    Id = "reg1",
                    StudentId = "student1",
                    StudentName = "Nguyễn Văn An",
                    StudentCode = "2021600001",
                    TopicId = "topic1",
                    TopicTitle = "Xây dựng hệ thống quản lý bán hàng trực tuyến",
                    CompanyId = "company1",
                    CompanyName = "FPT Software",
                    CoverLetterUrl = "uploads/cover_letters/student1_topic1.pdf",
                    Status = "approved",
                    RegisteredAt = DateTime.Now.AddDays(-15),
                    ApprovedAt = DateTime.Now.AddDays(-10)
                }
            };
        }

        public static List<InternshipRegistration> GetAllRegistrations()
        {
            return _registrations.ToList();
        }

        public static List<InternshipRegistration> GetRegistrationsByStudentId(string studentId)
        {
            return _registrations.Where(r => r.StudentId == studentId).ToList();
        }

        public static (bool Success, string Message, InternshipRegistration? Registration) CreateRegistration(InternshipRegistration registration)
        {
            // Validate
            var topic = _topics.FirstOrDefault(t => t.Id == registration.TopicId);
            if (topic == null)
            {
                return (false, "Đề tài không tồn tại", null);
            }

            if (topic.CurrentStudents >= topic.MaxStudents)
            {
                return (false, "Đề tài đã đủ số lượng sinh viên", null);
            }

            // Check if student already registered for this topic
            if (_registrations.Any(r => r.StudentId == registration.StudentId && r.TopicId == registration.TopicId))
            {
                return (false, "Bạn đã đăng ký đề tài này rồi", null);
            }

            // Create new registration
            registration.Id = $"reg{_registrations.Count + 1}";
            registration.RegisteredAt = DateTime.Now;
            registration.Status = "pending";
            _registrations.Add(registration);

            return (true, "Đăng ký thành công", registration);
        }

        #endregion
    }
}

