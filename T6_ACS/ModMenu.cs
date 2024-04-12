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
    public partial class ModMenu : Form
    {
        string getId;
        public ModMenu(string id)
        {
            InitializeComponent();
            getId = id;
        }

        private void ModMenu_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("C:\\CORE\\Kuliah\\Semester 4\\Praktikum\\ACS\\Week 6\\T6_ACS\\assets\\bg_login.png");
            this.BackgroundImageLayout = ImageLayout.Tile;

            lbWelcome.Text = "Welcome, " + getId;

            DB.openConnection();
            SqlCommand cmd = new SqlCommand("select th.trade_id as 'trade_id', th.sender as 'sender', th.recipient as 'recipient', i.item_name as 'item_name' from trade_history th join trade_details td on th.trade_id = td.trade_id join items i on td.item_id = i.item_id", DB.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtHistory = new DataTable();
            adapter.Fill(dtHistory);
            dgvHistory.DataSource = dtHistory;
            DB.closeConnection();

            DB.openConnection();
            SqlCommand inv = new SqlCommand("select i.item_name as 'item_name' from user_inventory ui join items i on ui.item_id = i.item_id where ui.growid = @id", DB.conn);
            inv.Parameters.AddWithValue("@id", getId);
            adapter = new SqlDataAdapter(inv);
            DataTable dtInv = new DataTable();
            adapter.Fill(dtInv);
            dgvInventory.DataSource = dtInv;
            DB.closeConnection();

            DB.openConnection();
            SqlCommand items = new SqlCommand("select item_id, item_name from items", DB.conn);
            adapter = new SqlDataAdapter(items); ;
            DataTable dtItems = new DataTable();
            adapter.Fill(dtItems);
            cbxItem.DataSource = dtItems;
            cbxItem.ValueMember = "item_id";
            cbxItem.DisplayMember = "item_name";
            DB.closeConnection();
        }

        void refreshDGV()
        {
            DB.openConnection();
            SqlCommand inv = new SqlCommand("select i.item_name as 'item_name' from user_inventory ui join items i on ui.item_id = i.item_id where ui.growid = @id", DB.conn);
            inv.Parameters.AddWithValue("@id", getId);
            SqlDataAdapter adapter = new SqlDataAdapter(inv);
            DataTable dtInv = new DataTable();
            adapter.Fill(dtInv);
            dgvInventory.DataSource = dtInv;
            DB.closeConnection();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            DB.openConnection();
            SqlCommand insInv = new SqlCommand("INSERT INTO user_inventory (growid, item_id) VALUES (@id, @iid)", DB.conn);
            insInv.Parameters.AddWithValue("@id", getId);
            insInv.Parameters.AddWithValue("@iid", cbxItem.SelectedValue);
            insInv.ExecuteNonQuery();
            DB.closeConnection();

            refreshDGV();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
