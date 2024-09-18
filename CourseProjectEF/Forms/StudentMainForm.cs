using CourseProjectEF.DbCotntext;
using CourseProjectEF.Entities;
using CourseProjectEF.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProjectEF.Forms
{
    public partial class frmStudentMain : Form
    {
        private readonly StudentService _studentService;
        public frmStudentMain()
        {
            InitializeComponent();
            _studentService = new StudentService();
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            dt1.DataSource = 
                _studentService.SearchStudent(txtSearchBar.Text);
        }

        private void frmStudentMain_Load(object sender, EventArgs e)
        {
            dt1.DataSource = _studentService.GetAllStudent();
            comboGrades.DataSource = _studentService.Grades();
            comboGrades.DisplayMember = "GradeName";
            comboGrades.ValueMember = "Id";

            btnDeleteStudent.Enabled = false;
            btnUpdate.Enabled = false;
            comboGrades.Enabled = false;
        }

        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            StudentCreateForm createForm = new StudentCreateForm(dt1,btnNewStudent);
            createForm.ShowDialog();
        }

        private void dt1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dt1.CurrentRow;
            var student = (Student)row.DataBoundItem;
            txtId.Text = student.Id.ToString();
            txtNamesurname.Text = student.NameSurname;
            txtPhonenumber.Text = student.PhoneNumber;
            comboGrades.SelectedValue = student.GradeId;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                Id = int.Parse(txtId.Text),
                NameSurname = txtNamesurname.Text,
                PhoneNumber = txtPhonenumber.Text,
                GradeId = (int)comboGrades.SelectedValue
            };
            _studentService.UpdateStudent(student);
            MessageBox.Show($"{student.NameSurname} Adlı Öğrenci Güncellenmiştir.","Bilgi");
            dt1.DataSource = _studentService.GetAllStudent();
            TextboxClear();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            int studentId = int.Parse(txtId.Text);
            DialogResult  result = MessageBox.Show($"{txtNamesurname.Text} Adlı Öğrenci Silinecektir Eminmisiniz ?","Uyarı",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                _studentService.DeleteStudent(studentId);
                dt1.DataSource = _studentService.GetAllStudent();
                TextboxClear();
            }
            else
            {
                MessageBox.Show("Silme İşlemi İptal Edilmiştir.","Bilgi");
            }
            

            
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text.Length > 0 && !string.IsNullOrEmpty(txtId.Text))
            {
                btnDeleteStudent.Enabled = true;
                btnUpdate.Enabled = true;
                comboGrades.Enabled = true;
            }
            else
            {
                btnDeleteStudent.Enabled=false;
                btnUpdate.Enabled = false;
                comboGrades.Enabled=false;
            }
        }
        private void TextboxClear()
        {
            txtId.Text = null;
            txtNamesurname.Text = null;
            txtPhonenumber.Text = null;
            
            
        }
    }
}
