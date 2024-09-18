using CourseProjectEF.Forms;
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

namespace CourseProjectEF
{
    public partial class frmLogin : Form
    {
        private readonly UserService _userService;
        public frmLogin()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = "melih.kamar";
            string password = "123456";
            bool isLogin = _userService.Login(userName, password);
            if (isLogin)
            {
                MessageBox.Show("Giriş Başarılı!");
                frmStudentMain frm = new frmStudentMain();
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız!");
            }
        }
    }
}
