using CourseProjectEF.Entities;
using CourseProjectEF.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CourseProjectEF.Forms
{
    public partial class StudentCreateForm : Form
    {
        StudentService _studentService;
        DataGridView _dataGrid;
        Button _button;
        public StudentCreateForm(DataGridView dataGrid,Button button)
        {
            InitializeComponent();
            _studentService = new StudentService();
            _dataGrid = dataGrid;
            _button = button;
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                NameSurname = txtNamesurname.Text,
                PhoneNumber = txtPhoneNumber.Text,
                GradeId = Convert.ToInt32(comboGrades.SelectedValue)
            };
            bool result = _studentService.AddStudent(student);
            if (result)
            {
                MessageBox.Show("Öğrenci Oluşturuldu.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                _dataGrid.DataSource = _studentService.GetAllStudent();
                _button.BackColor = Color.Red;
                _button.ForeColor = Color.White;
            }

        }

        private void StudentCreateForm_Load(object sender, EventArgs e)
        {
            comboGrades.DataSource = _studentService.Grades();
            comboGrades.DisplayMember = "GradeName";
            comboGrades.ValueMember = "Id";
        }

        
    }
}
