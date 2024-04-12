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
    public partial class HomeMod : Form
    {
        string getId;
        List<Button> btnUser1;
        List<Button> btnUser2;
        private bool isFirstLoad = false;
        bool btnAcc1Clicked = false;
        bool btnAcc2Clicked = false;
        public HomeMod(string id)
        {
            InitializeComponent();
            getId = id;
            btnUser1 = new List<Button>
            {
                btn1,
                btn2,
                btn3,
                btn4,

            };
            btnUser2 = new List<Button>
            {
                btn5,
                btn6,
                btn7,
                btn8,

            };
        }

        private void HomeMod_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("C:\\CORE\\Kuliah\\Semester 4\\Praktikum\\ACS\\Week 6\\T6_ACS\\assets\\bg_login.png");
            this.BackgroundImageLayout = ImageLayout.Tile;

            lbWelcome.Text = "Welcome, " + getId;
            lbTrade1.Text = getId + "'s offer";

            DB.openConnection();
            SqlCommand users = new SqlCommand("select * from users where growid <> @id ", DB.conn);
            users.Parameters.AddWithValue("@id", getId);
            SqlDataAdapter adapter = new SqlDataAdapter(users); ;
            DataTable dtUsers = new DataTable();
            adapter.Fill(dtUsers);
            cbxUsers.DataSource = dtUsers;
            cbxUsers.ValueMember = "growid";
            cbxUsers.DisplayMember = "growid";
            DB.closeConnection();

            lbTrade1.Enabled = false;
            lbTrade2.Enabled = false;
            cbxItem1.Enabled = false;
            cbxItem2.Enabled = false;
            btnAcc1.Enabled = false;
            btnAcc2.Enabled = false;

            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";

            isFirstLoad = true;
        }

        private void cbxUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";

            lbTrade1.Enabled = true;
            lbTrade2.Enabled = true;
            cbxItem1.Enabled = true;
            cbxItem2.Enabled = true;
            btnAcc1.Enabled = true;
            btnAcc2.Enabled = true;
            lbTrade2.Text = cbxUsers.SelectedValue + "'s offer";

            DB.openConnection();
            SqlCommand item1 = new SqlCommand("select i.item_name as 'item_name', ui.item_id as 'item_id' from user_inventory ui join items i on ui.item_id = i.item_id where ui.growid = @id", DB.conn);
            item1.Parameters.AddWithValue("@id", getId);
            SqlDataAdapter adapter = new SqlDataAdapter(item1);
            DataTable dtItem1 = new DataTable();
            adapter.Fill(dtItem1);
            cbxItem1.DataSource = dtItem1;
            cbxItem1.ValueMember = "item_id";
            cbxItem1.DisplayMember = "item_name";

            if (isFirstLoad)
            {
                SqlCommand item2 = new SqlCommand("select i.item_name as 'item_name', ui.item_id as 'item_id' from user_inventory ui join items i on ui.item_id = i.item_id where ui.growid = @id", DB.conn);
                item2.Parameters.AddWithValue("@id", cbxUsers.SelectedValue);
                adapter = new SqlDataAdapter(item2);
                DataTable dtItem2 = new DataTable();
                adapter.Fill(dtItem2);
                cbxItem2.DataSource = dtItem2;
                cbxItem2.ValueMember = "item_id";
                cbxItem2.DisplayMember = "item_name";
            }
            DB.closeConnection();

            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
        }

        private void cbxItem1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isFirstLoad)
            {
                DB.openConnection();
                SqlCommand check = new SqlCommand("select count(*) from user_inventory where growid = @id", DB.conn);
                check.Parameters.AddWithValue("@id", getId);
                int cek = Convert.ToInt32(check.ExecuteScalar());
                DB.closeConnection();

                if (cek != 0)
                {
                    foreach (Button btn in btnUser1)
                    {
                        if (btn.Text == "")
                        {
                            DB.openConnection();
                            try
                            {
                                SqlCommand cmd = new SqlCommand("select i.item_name as 'item_name' from user_inventory ui join items i on ui.item_id = i.item_id where ui.item_id = @id", DB.conn);
                                cmd.Parameters.AddWithValue("@id", cbxItem1.SelectedValue);

                                btn.Text = Convert.ToString(cmd.ExecuteScalar());


                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            DB.closeConnection();

                            break;
                        }
                    }
                }
            }
        }

        private void cbxItem2_SelectedValueChanged(object sender, EventArgs e)
        {
            DB.openConnection();
            SqlCommand check = new SqlCommand("select count(*) from user_inventory where growid = @id", DB.conn);
            check.Parameters.AddWithValue("@id", cbxUsers.SelectedValue);
            int cek = Convert.ToInt32(check.ExecuteScalar());
            DB.closeConnection();

            if (cek != 0)
            {
                foreach (Button btn in btnUser2)
                {
                    if (btn.Text == "")
                    {
                        DB.openConnection();
                        try
                        {
                            if (isFirstLoad)
                            {

                                SqlCommand cmd = new SqlCommand("select i.item_name as 'item_name' from user_inventory ui join items i on ui.item_id = i.item_id where ui.item_id = @id", DB.conn);
                                cmd.Parameters.AddWithValue("@id", cbxItem2.SelectedValue);

                                btn.Text = Convert.ToString(cmd.ExecuteScalar());

                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        DB.closeConnection();

                        break;
                    }
                }
            }
        }

        private void btnAcc1_Click(object sender, EventArgs e)
        {
            btnAcc1Clicked = true;
            btnAcc1.Enabled = false;
            CheckTransaction();
        }

        private void btnAcc2_Click(object sender, EventArgs e)
        {
            btnAcc2Clicked = true;
            btnAcc2.Enabled = false;
            CheckTransaction();
        }

        private void CheckTransaction()
        {
            if (btnAcc1Clicked && btnAcc2Clicked)
            {
                DB.conn.Open();
                SqlTransaction transaction = DB.conn.BeginTransaction();

                try
                {
                    SqlCommand insTH = new SqlCommand("INSERT INTO trade_history (sender, recipient) VALUES (@send, @reci); SELECT SCOPE_IDENTITY();", DB.conn, transaction);
                    insTH.Parameters.AddWithValue("@send", getId);
                    insTH.Parameters.AddWithValue("@reci", cbxUsers.SelectedValue);
                    int id_th = Convert.ToInt32(insTH.ExecuteScalar());

                    foreach (Button btn in btnUser1)
                    {
                        if (btn.Text != "")
                        {
                            SqlCommand cmd = new SqlCommand("SELECT item_id FROM items WHERE item_name = @name", DB.conn, transaction);
                            cmd.Parameters.AddWithValue("@name", btn.Text);

                            SqlCommand insTD = new SqlCommand("INSERT INTO trade_details (trade_id, item_id) VALUES (@tid, @iid)", DB.conn, transaction);
                            insTD.Parameters.AddWithValue("@tid", id_th);
                            insTD.Parameters.AddWithValue("@iid", Convert.ToInt32(cmd.ExecuteScalar()));
                            insTD.ExecuteNonQuery();

                            SqlCommand insInv = new SqlCommand("INSERT INTO user_inventory (growid, item_id) VALUES (@id, @iid)", DB.conn, transaction);
                            insInv.Parameters.AddWithValue("@id", cbxUsers.SelectedValue);
                            insInv.Parameters.AddWithValue("@iid", Convert.ToInt32(cmd.ExecuteScalar()));
                            insInv.ExecuteNonQuery();

                            SqlCommand delInv = new SqlCommand("delete from user_inventory where growid = @id and item_id = @iid", DB.conn, transaction);
                            delInv.Parameters.AddWithValue("@id", getId);
                            delInv.Parameters.AddWithValue("@iid", Convert.ToInt32(cmd.ExecuteScalar()));
                            delInv.ExecuteNonQuery();
                        }
                    }

                    SqlCommand insTH2 = new SqlCommand("insert into trade_history (sender, recipient) values (@send,@reci); SELECT SCOPE_IDENTITY();", DB.conn, transaction);
                    insTH2.Parameters.AddWithValue("@send", cbxUsers.SelectedValue);
                    insTH2.Parameters.AddWithValue("@reci", getId);
                    int id_th2 = Convert.ToInt32(insTH2.ExecuteScalar());

                    foreach (Button btn in btnUser2)
                    {
                        if (btn.Text != "")
                        {
                            SqlCommand cmd = new SqlCommand("select item_id from items where item_name = @name", DB.conn, transaction);
                            cmd.Parameters.AddWithValue("@name", btn.Text);

                            SqlCommand insTD = new SqlCommand("insert into trade_details (trade_id, item_id) values (@tid,@iid)", DB.conn, transaction);
                            insTD.Parameters.AddWithValue("@tid", id_th2);
                            insTD.Parameters.AddWithValue("@iid", Convert.ToInt32(cmd.ExecuteScalar()));
                            insTD.ExecuteNonQuery();

                            SqlCommand insInv = new SqlCommand("INSERT INTO user_inventory (growid, item_id) VALUES (@id, @iid)", DB.conn, transaction);
                            insInv.Parameters.AddWithValue("@id", getId);
                            insInv.Parameters.AddWithValue("@iid", Convert.ToInt32(cmd.ExecuteScalar()));
                            insInv.ExecuteNonQuery();

                            SqlCommand delInv = new SqlCommand("delete from user_inventory where growid = @id and item_id = @iid", DB.conn, transaction);
                            delInv.Parameters.AddWithValue("@id", cbxUsers.SelectedValue);
                            delInv.Parameters.AddWithValue("@iid", Convert.ToInt32(cmd.ExecuteScalar()));
                            delInv.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Trade has been completed");
                    btnAcc1Clicked = false;
                    btnAcc2Clicked = false;
                    btnAcc1.Enabled = true;
                    btnAcc2.Enabled = true;

                    btn1.Text = "";
                    btn2.Text = "";
                    btn3.Text = "";
                    btn4.Text = "";
                    btn5.Text = "";
                    btn6.Text = "";
                    btn7.Text = "";
                    btn8.Text = "";

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message.ToString(), "Failed to insert transaction data");
                }

                DB.conn.Close();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btn1.Text = "";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btn2.Text = "";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btn3.Text = "";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            btn4.Text = "";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            btn5.Text = "";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            btn6.Text = "";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            btn7.Text = "";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            btn8.Text = "";
        }

        private void btnMod_Click(object sender, EventArgs e)
        {

        }
    }
}
