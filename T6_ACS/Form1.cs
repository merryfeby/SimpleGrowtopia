using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T6_ACS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pbBackground.Image = Image.FromFile("C:\\CORE\\Kuliah\\Semester 4\\Praktikum\\ACS\\Week 6\\T6_ACS\\assets\\bg_home.png");
            //pbLogo.Image = Image.FromFile("C:\\CORE\\Kuliah\\Semester 4\\Praktikum\\ACS\\Week 6\\T6_ACS\\assets\\growtopia_logo.png");
            //pictureBox1.Image = Image.FromFile("D:\\KULIAH\\ashor\\sem4\\ACS\\TutorMaster\\testgambar.jpg");
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLogin.Cursor = Cursors.Hand;

            btnQuit.FlatAppearance.BorderSize = 0;
            btnQuit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnQuit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnQuit.Cursor = Cursors.Hand;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.ShowDialog();
            //this.Hide();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
