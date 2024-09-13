using CourseProjectEF.DbCotntext;
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
            dataGridView1.DataSource = 
                _studentService.SearchStudent(txtSearchBar.Text);
        }

        private void frmStudentMain_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _studentService.GetAllStudent();
        }
    }
}
