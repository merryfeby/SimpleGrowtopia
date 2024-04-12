using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace T6_ACS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("C:\\CORE\\Kuliah\\Semester 4\\Praktikum\\ACS\\Week 6\\T6_ACS\\assets\\bg_login.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string id = tbxID.Text;
            string pass = tbxPassword.Text;

            try
            {
                DB.openConnection();
                SqlCommand check = new SqlCommand("Select count(*) from users where growid = @id and password = @pass", DB.conn);
                check.Parameters.AddWithValue("@id", id);
                check.Parameters.AddWithValue("@pass", pass);
                int cek = Convert.ToInt32(check.ExecuteScalar());

                if (cek != 0)
                {
                    SqlCommand cekRole = new SqlCommand("Select count(*) from users where growid = @id and password = @pass and is_mod = 1", DB.conn);
                    cekRole.Parameters.AddWithValue("@id", id);
                    cekRole.Parameters.AddWithValue("@pass", pass);
                    int cekMod = Convert.ToInt32(cekRole.ExecuteScalar());

                    if (cekMod != 0)
                    {
                        HomeMod form = new HomeMod(id);
                        form.ShowDialog();
                        this.Hide();
                    } 
                    else
                    {
                        HomeUser form = new HomeUser(id);
                        form.ShowDialog();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }
                DB.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
