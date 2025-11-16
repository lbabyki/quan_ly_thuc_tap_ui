using MyWinFormsApp.Business.Models;
using System;
using System.Windows.Forms;

namespace MyWinFormsApp.UI.Forms
{
    public partial class InternshipPeriodDialog : Form
    {
        public InternshipPeriod? PeriodData { get; private set; }
        private bool _isEditMode = false;

        public InternshipPeriodDialog()
        {
            InitializeComponent();
            _isEditMode = false;
            this.Text = "Tạo Kỳ Thực Tập Mới";
        }

        public InternshipPeriodDialog(InternshipPeriod period)
        {
            InitializeComponent();
            _isEditMode = true;
            this.Text = "Chỉnh Sửa Kỳ Thực Tập";
            LoadPeriodData(period);
        }

        private void LoadPeriodData(InternshipPeriod period)
        {
            txtName.Text = period.Name;
            txtDescription.Text = period.Description ?? string.Empty;
            cboSemester.SelectedItem = period.Semester.ToString();
            txtAcademicYear.Text = period.AcademicYear;
            dtpStartDate.Value = period.StartDate;
            dtpEndDate.Value = period.EndDate;
            dtpRegistrationDeadline.Value = period.RegistrationDeadline;
            dtpReportDeadline.Value = period.ReportDeadline;
            
            if (period.DefenseDate.HasValue)
            {
                dtpDefenseDate.Value = period.DefenseDate.Value;
            }
            
            txtNotes.Text = period.Notes ?? string.Empty;

            PeriodData = period;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên kỳ thực tập!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAcademicYear.Text))
            {
                MessageBox.Show("Vui lòng nhập năm học!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAcademicYear.Focus();
                return;
            }

            if (cboSemester.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn học kỳ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSemester.Focus();
                return;
            }

            if (dtpStartDate.Value >= dtpEndDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpRegistrationDeadline.Value >= dtpStartDate.Value)
            {
                MessageBox.Show("Hạn đăng ký phải trước ngày bắt đầu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpReportDeadline.Value <= dtpStartDate.Value || dtpReportDeadline.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Hạn nộp báo cáo phải trong khoảng thời gian thực tập!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create or update period data
            if (PeriodData == null)
            {
                PeriodData = new InternshipPeriod();
            }

            PeriodData.Name = txtName.Text.Trim();
            PeriodData.Description = txtDescription.Text.Trim();
            PeriodData.Semester = int.Parse(cboSemester.SelectedItem.ToString()!);
            PeriodData.AcademicYear = txtAcademicYear.Text.Trim();
            PeriodData.StartDate = dtpStartDate.Value;
            PeriodData.EndDate = dtpEndDate.Value;
            PeriodData.RegistrationDeadline = dtpRegistrationDeadline.Value;
            PeriodData.ReportDeadline = dtpReportDeadline.Value;
            PeriodData.DefenseDate = dtpDefenseDate.Value;
            PeriodData.Notes = txtNotes.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InternshipPeriodDialog_Load(object sender, EventArgs e)
        {
            // Initialize semester combo box
            cboSemester.Items.Clear();
            cboSemester.Items.Add("1");
            cboSemester.Items.Add("2");
            cboSemester.Items.Add("3");
            
            if (!_isEditMode)
            {
                cboSemester.SelectedIndex = 0;
                
                // Set default dates
                dtpStartDate.Value = DateTime.Now.AddMonths(1);
                dtpEndDate.Value = DateTime.Now.AddMonths(4);
                dtpRegistrationDeadline.Value = DateTime.Now.AddDays(15);
                dtpReportDeadline.Value = DateTime.Now.AddMonths(4).AddDays(-10);
                dtpDefenseDate.Value = DateTime.Now.AddMonths(4).AddDays(-2);
            }
        }
    }
}

