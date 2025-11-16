using System;
using System.Drawing;
using System.Windows.Forms;
using MyWinFormsApp.Business.Models;

namespace MyWinFormsApp.Forms
{
    /// <summary>
    /// Dialog for creating/editing internship topics
    /// </summary>
    public partial class TopicDialog : Form
    {
        private readonly Color PRIMARY_COLOR = ColorTranslator.FromHtml("#0054A6");
        private readonly Color SECONDARY_COLOR = ColorTranslator.FromHtml("#F36F21");

        public bool IsEditMode { get; private set; }
        public InternshipTopic? TopicData { get; private set; }

        private TextBox txtTitle = null!;
        private TextBox txtDescription = null!;
        private TextBox txtCompanyName = null!;
        private TextBox txtRequirements = null!;
        private TextBox txtSkills = null!;
        private NumericUpDown numMaxStudents = null!;
        private DateTimePicker dtpStartDate = null!;
        private DateTimePicker dtpEndDate = null!;
        private DateTimePicker dtpDeadline = null!;
        private ComboBox cboStatus = null!;
        private Button btnSave = null!;
        private Button btnCancel = null!;

        public TopicDialog(InternshipTopic? existingTopic = null)
        {
            IsEditMode = existingTopic != null;
            TopicData = existingTopic;

            InitializeComponent();
            SetupForm();
            LoadData();
        }

        private void SetupForm()
        {
            this.Text = IsEditMode ? "Chỉnh sửa đề tài" : "Tạo mới đề tài";
            this.Size = new Size(600, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                AutoScroll = true
            };

            int yPos = 10;

            // Title
            var lblTitle = new Label
            {
                Text = this.Text,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = PRIMARY_COLOR,
                Location = new Point(0, yPos),
                Size = new Size(540, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel.Controls.Add(lblTitle);
            yPos += 50;

            // Topic Title
            AddLabel(panel, ref yPos, "Tiêu đề đề tài: *");
            txtTitle = new TextBox
            {
                Location = new Point(0, yPos),
                Size = new Size(540, 30),
                Font = new Font("Segoe UI", 10F)
            };
            panel.Controls.Add(txtTitle);
            yPos += 40;

            // Description
            AddLabel(panel, ref yPos, "Mô tả: *");
            txtDescription = new TextBox
            {
                Location = new Point(0, yPos),
                Size = new Size(540, 80),
                Font = new Font("Segoe UI", 10F),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            panel.Controls.Add(txtDescription);
            yPos += 90;

            // Company Name
            AddLabel(panel, ref yPos, "Tên công ty: *");
            txtCompanyName = new TextBox
            {
                Location = new Point(0, yPos),
                Size = new Size(540, 30),
                Font = new Font("Segoe UI", 10F)
            };
            panel.Controls.Add(txtCompanyName);
            yPos += 40;

            // Requirements
            AddLabel(panel, ref yPos, "Yêu cầu:");
            txtRequirements = new TextBox
            {
                Location = new Point(0, yPos),
                Size = new Size(540, 60),
                Font = new Font("Segoe UI", 10F),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            panel.Controls.Add(txtRequirements);
            yPos += 70;

            // Skills
            AddLabel(panel, ref yPos, "Kỹ năng yêu cầu:");
            txtSkills = new TextBox
            {
                Location = new Point(0, yPos),
                Size = new Size(540, 30),
                Font = new Font("Segoe UI", 10F)
            };
            panel.Controls.Add(txtSkills);
            yPos += 40;

            // Max Students
            AddLabel(panel, ref yPos, "Số lượng sinh viên tối đa:");
            numMaxStudents = new NumericUpDown
            {
                Location = new Point(0, yPos),
                Size = new Size(540, 30),
                Font = new Font("Segoe UI", 10F),
                Minimum = 1,
                Maximum = 50,
                Value = 1
            };
            panel.Controls.Add(numMaxStudents);
            yPos += 40;

            // Start Date
            AddLabel(panel, ref yPos, "Ngày bắt đầu:");
            dtpStartDate = new DateTimePicker
            {
                Location = new Point(0, yPos),
                Size = new Size(540, 30),
                Font = new Font("Segoe UI", 10F),
                Format = DateTimePickerFormat.Short
            };
            panel.Controls.Add(dtpStartDate);
            yPos += 40;

            // End Date
            AddLabel(panel, ref yPos, "Ngày kết thúc:");
            dtpEndDate = new DateTimePicker
            {
                Location = new Point(0, yPos),
                Size = new Size(540, 30),
                Font = new Font("Segoe UI", 10F),
                Format = DateTimePickerFormat.Short
            };
            panel.Controls.Add(dtpEndDate);
            yPos += 40;

            // Deadline
            AddLabel(panel, ref yPos, "Hạn đăng ký:");
            dtpDeadline = new DateTimePicker
            {
                Location = new Point(0, yPos),
                Size = new Size(540, 30),
                Font = new Font("Segoe UI", 10F),
                Format = DateTimePickerFormat.Short
            };
            panel.Controls.Add(dtpDeadline);
            yPos += 40;

            // Status
            AddLabel(panel, ref yPos, "Trạng thái:");
            cboStatus = new ComboBox
            {
                Location = new Point(0, yPos),
                Size = new Size(540, 30),
                Font = new Font("Segoe UI", 10F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboStatus.Items.AddRange(new object[] { "pending", "approved", "rejected", "in_progress", "completed" });
            cboStatus.SelectedIndex = 0;
            panel.Controls.Add(cboStatus);
            yPos += 50;

            // Buttons
            var btnPanel = new Panel
            {
                Location = new Point(0, yPos),
                Size = new Size(540, 50)
            };

            btnSave = new Button
            {
                Text = IsEditMode ? "Cập nhật" : "Tạo mới",
                Size = new Size(120, 40),
                Location = new Point(150, 5),
                BackColor = SECONDARY_COLOR,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "Hủy",
                Size = new Size(120, 40),
                Location = new Point(280, 5),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            btnPanel.Controls.Add(btnSave);
            btnPanel.Controls.Add(btnCancel);
            panel.Controls.Add(btnPanel);

            this.Controls.Add(panel);
        }

        private void AddLabel(Panel panel, ref int yPos, string text)
        {
            var lbl = new Label
            {
                Text = text,
                Location = new Point(0, yPos),
                Size = new Size(540, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = text.Contains("*") ? PRIMARY_COLOR : Color.Black
            };
            panel.Controls.Add(lbl);
            yPos += 25;
        }

        private void LoadData()
        {
            if (!IsEditMode || TopicData == null) return;

            txtTitle.Text = TopicData.Title;
            txtDescription.Text = TopicData.Description;
            txtCompanyName.Text = TopicData.CompanyName;
            txtRequirements.Text = TopicData.Requirements;
            txtSkills.Text = TopicData.Skills;
            numMaxStudents.Value = TopicData.MaxStudents;

            if (TopicData.StartDate.HasValue)
                dtpStartDate.Value = TopicData.StartDate.Value;
            if (TopicData.EndDate.HasValue)
                dtpEndDate.Value = TopicData.EndDate.Value;
            if (TopicData.Deadline.HasValue)
                dtpDeadline.Value = TopicData.Deadline.Value;

            if (!string.IsNullOrEmpty(TopicData.Status))
            {
                int statusIndex = cboStatus.Items.IndexOf(TopicData.Status);
                if (statusIndex >= 0) cboStatus.SelectedIndex = statusIndex;
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TopicData = CreateTopicObject();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtDescription.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text)) return false;
            return true;
        }

        private InternshipTopic CreateTopicObject()
        {
            var topic = TopicData ?? new InternshipTopic();

            topic.Title = txtTitle.Text.Trim();
            topic.Description = txtDescription.Text.Trim();
            topic.CompanyName = txtCompanyName.Text.Trim();
            topic.Requirements = txtRequirements.Text.Trim();
            topic.Skills = txtSkills.Text.Trim();
            topic.MaxStudents = (int)numMaxStudents.Value;
            topic.StartDate = dtpStartDate.Value;
            topic.EndDate = dtpEndDate.Value;
            topic.Deadline = dtpDeadline.Value;
            topic.Status = cboStatus.SelectedItem?.ToString() ?? "pending";

            if (!IsEditMode)
            {
                topic.CreatedAt = DateTime.Now;
                topic.CurrentStudents = 0;
            }
            else
            {
                topic.UpdatedAt = DateTime.Now;
            }

            return topic;
        }
    }
}

