using QLGiay.Utilities;
using QLUniqlo.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLGiay.UI
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            customizeDesing();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(childForm);
            pnlContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void customizeDesing()
        {
            pnlHomeSubmenu.Visible = false;
            pnlSideMenu.Visible = true;
            //panelPlaylistSubMenu.Visible = false;
            //panelToolsSubMenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (pnlHomeSubmenu.Visible == true) pnlHomeSubmenu.Visible = false;
            if (pnlSideMenu.Visible == false) pnlSideMenu.Visible = true;
        }

        private void showSideBar(Panel sidebar)
        {
            if (sidebar.Visible == true)
            {
                hideSubMenu();
                sidebar.Visible = false;
            }else sidebar.Visible = true;
        }

        private void showSubMenu(Panel submenu)
        {
            if(submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }else submenu.Visible = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
                tssLoginName.Text += WorkingContext.Instance.CurrentLoginName;
                tssBranch.Text += WorkingContext.Instance.CurrentBranch;
                tssGroup.Text += WorkingContext.Instance.CurrentLoginInfo.RoleName;
            //chỗ form main này em sẽ kiểm tra để nếu là nhân viên thì sẽ ẩn nút btnDalat_Click
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlHomeSubmenu);
        }

        private void btnDaLat_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnNhaTrang_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            showSideBar(pnlSideMenu);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            openChildForm(new frmEmployee());
            hideSubMenu();
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            openChildForm(new frmStatistical());
            hideSubMenu();
        }
    }
}
