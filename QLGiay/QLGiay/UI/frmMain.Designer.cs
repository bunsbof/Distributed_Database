
namespace QLGiay.UI
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnHome = new System.Windows.Forms.Button();
            this.pnlHomeSubmenu = new System.Windows.Forms.Panel();
            this.btnLady = new System.Windows.Forms.Button();
            this.btnGentlemen = new System.Windows.Forms.Button();
            this.pnlSideMenu = new System.Windows.Forms.Panel();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.pnlManageSubMenu = new System.Windows.Forms.Panel();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnManagement = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssLoginName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssBranch = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssGroup = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlHomeSubmenu.SuspendLayout();
            this.pnlSideMenu.SuspendLayout();
            this.pnlManageSubMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 56);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(321, 63);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // pnlHomeSubmenu
            // 
            this.pnlHomeSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.pnlHomeSubmenu.Controls.Add(this.btnLady);
            this.pnlHomeSubmenu.Controls.Add(this.btnGentlemen);
            this.pnlHomeSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHomeSubmenu.Location = new System.Drawing.Point(0, 119);
            this.pnlHomeSubmenu.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHomeSubmenu.Name = "pnlHomeSubmenu";
            this.pnlHomeSubmenu.Size = new System.Drawing.Size(321, 120);
            this.pnlHomeSubmenu.TabIndex = 2;
            // 
            // btnLady
            // 
            this.btnLady.FlatAppearance.BorderSize = 0;
            this.btnLady.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLady.ForeColor = System.Drawing.Color.LightGray;
            this.btnLady.Location = new System.Drawing.Point(0, 56);
            this.btnLady.Margin = new System.Windows.Forms.Padding(4);
            this.btnLady.Name = "btnLady";
            this.btnLady.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnLady.Size = new System.Drawing.Size(317, 56);
            this.btnLady.TabIndex = 1;
            this.btnLady.Text = "Lady";
            this.btnLady.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLady.UseVisualStyleBackColor = true;
            // 
            // btnGentlemen
            // 
            this.btnGentlemen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGentlemen.FlatAppearance.BorderSize = 0;
            this.btnGentlemen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGentlemen.ForeColor = System.Drawing.Color.LightGray;
            this.btnGentlemen.Location = new System.Drawing.Point(0, 0);
            this.btnGentlemen.Margin = new System.Windows.Forms.Padding(4);
            this.btnGentlemen.Name = "btnGentlemen";
            this.btnGentlemen.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnGentlemen.Size = new System.Drawing.Size(321, 56);
            this.btnGentlemen.TabIndex = 0;
            this.btnGentlemen.Text = "Gentlemen";
            this.btnGentlemen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGentlemen.UseVisualStyleBackColor = true;
            // 
            // pnlSideMenu
            // 
            this.pnlSideMenu.AutoScroll = true;
            this.pnlSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.pnlSideMenu.Controls.Add(this.btnRevenue);
            this.pnlSideMenu.Controls.Add(this.btnCustomer);
            this.pnlSideMenu.Controls.Add(this.pnlManageSubMenu);
            this.pnlSideMenu.Controls.Add(this.btnManagement);
            this.pnlSideMenu.Controls.Add(this.pnlHomeSubmenu);
            this.pnlSideMenu.Controls.Add(this.btnHome);
            this.pnlSideMenu.Controls.Add(this.panel1);
            this.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSideMenu.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(321, 1031);
            this.pnlSideMenu.TabIndex = 0;
            // 
            // btnRevenue
            // 
            this.btnRevenue.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRevenue.FlatAppearance.BorderSize = 0;
            this.btnRevenue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevenue.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRevenue.Image = ((System.Drawing.Image)(resources.GetObject("btnRevenue.Image")));
            this.btnRevenue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRevenue.Location = new System.Drawing.Point(0, 432);
            this.btnRevenue.Margin = new System.Windows.Forms.Padding(4);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(321, 63);
            this.btnRevenue.TabIndex = 7;
            this.btnRevenue.Text = "Revenue";
            this.btnRevenue.UseVisualStyleBackColor = true;
            // 
            // btnCustomer
            // 
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Image")));
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.Location = new System.Drawing.Point(0, 369);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(321, 63);
            this.btnCustomer.TabIndex = 6;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            // 
            // pnlManageSubMenu
            // 
            this.pnlManageSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.pnlManageSubMenu.Controls.Add(this.btnCategory);
            this.pnlManageSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlManageSubMenu.Location = new System.Drawing.Point(0, 302);
            this.pnlManageSubMenu.Margin = new System.Windows.Forms.Padding(4);
            this.pnlManageSubMenu.Name = "pnlManageSubMenu";
            this.pnlManageSubMenu.Size = new System.Drawing.Size(321, 67);
            this.pnlManageSubMenu.TabIndex = 4;
            // 
            // btnCategory
            // 
            this.btnCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.ForeColor = System.Drawing.Color.LightGray;
            this.btnCategory.Location = new System.Drawing.Point(0, 0);
            this.btnCategory.Margin = new System.Windows.Forms.Padding(4);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnCategory.Size = new System.Drawing.Size(321, 56);
            this.btnCategory.TabIndex = 1;
            this.btnCategory.Text = "Category";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.UseVisualStyleBackColor = true;
            // 
            // btnManagement
            // 
            this.btnManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManagement.FlatAppearance.BorderSize = 0;
            this.btnManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagement.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnManagement.Image")));
            this.btnManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagement.Location = new System.Drawing.Point(0, 239);
            this.btnManagement.Margin = new System.Windows.Forms.Padding(4);
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new System.Drawing.Size(321, 63);
            this.btnManagement.TabIndex = 3;
            this.btnManagement.Text = "Manage";
            this.btnManagement.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 56);
            this.panel1.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.ForeColor = System.Drawing.Color.LightGray;
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(61, 56);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(321, 964);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1579, 67);
            this.panel2.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLoginName,
            this.tssBranch,
            this.tssGroup});
            this.statusStrip1.Location = new System.Drawing.Point(0, 41);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1579, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLoginName
            // 
            this.tssLoginName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.tssLoginName.ForeColor = System.Drawing.Color.White;
            this.tssLoginName.Name = "tssLoginName";
            this.tssLoginName.Size = new System.Drawing.Size(110, 20);
            this.tssLoginName.Text = "Tên đăng nhập:";
            // 
            // tssBranch
            // 
            this.tssBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.tssBranch.ForeColor = System.Drawing.Color.White;
            this.tssBranch.Name = "tssBranch";
            this.tssBranch.Size = new System.Drawing.Size(77, 20);
            this.tssBranch.Text = "Chi nhánh:";
            // 
            // tssGroup
            // 
            this.tssGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.tssGroup.ForeColor = System.Drawing.Color.White;
            this.tssGroup.Name = "tssGroup";
            this.tssGroup.Size = new System.Drawing.Size(53, 20);
            this.tssGroup.Text = "Nhóm:";
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(321, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1579, 964);
            this.pnlContainer.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1579, 964);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1900, 1031);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlSideMenu);
            this.Font = new System.Drawing.Font("Candara Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1216, 821);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lazyboyempires";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlHomeSubmenu.ResumeLayout(false);
            this.pnlSideMenu.ResumeLayout(false);
            this.pnlManageSubMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel pnlHomeSubmenu;
        private System.Windows.Forms.Button btnLady;
        private System.Windows.Forms.Button btnGentlemen;
        private System.Windows.Forms.Panel pnlSideMenu;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Panel pnlManageSubMenu;
        private System.Windows.Forms.Button btnManagement;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRevenue;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssLoginName;
        private System.Windows.Forms.ToolStripStatusLabel tssBranch;
        private System.Windows.Forms.ToolStripStatusLabel tssGroup;
    }
}