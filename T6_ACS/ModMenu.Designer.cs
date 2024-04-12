
namespace T6_ACS
{
    partial class ModMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModMenu));
            this.lbWelcome = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.cbxItem = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Location = new System.Drawing.Point(22, 21);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(46, 17);
            this.lbWelcome.TabIndex = 0;
            this.lbWelcome.Text = "label1";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(204, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightCoral;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(670, 24);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(106, 45);
            this.btnLogout.TabIndex = 36;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "Transaction History";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(700, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "My Inventory";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(25, 103);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.RowTemplate.Height = 24;
            this.dgvHistory.Size = new System.Drawing.Size(380, 148);
            this.dgvHistory.TabIndex = 39;
            // 
            // dgvInventory
            // 
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(411, 298);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.RowHeadersWidth = 51;
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.Size = new System.Drawing.Size(377, 172);
            this.dgvInventory.TabIndex = 40;
            // 
            // cbxItem
            // 
            this.cbxItem.FormattingEnabled = true;
            this.cbxItem.Location = new System.Drawing.Point(180, 298);
            this.cbxItem.Name = "cbxItem";
            this.cbxItem.Size = new System.Drawing.Size(225, 24);
            this.cbxItem.TabIndex = 41;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(330, 328);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 42;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ModMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbxItem);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lbWelcome);
            this.Name = "ModMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModMenu";
            this.Load += new System.EventHandler(this.ModMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.ComboBox cbxItem;
        private System.Windows.Forms.Button btnAdd;
    }
}