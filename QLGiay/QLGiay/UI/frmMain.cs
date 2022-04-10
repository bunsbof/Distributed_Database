using QLGiay.Utilities;
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
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
                tssLoginName.Text += WorkingContext.Instance.CurrentLoginName;
                tssBranch.Text += WorkingContext.Instance.CurrentBranch;
                tssGroup.Text += WorkingContext.Instance.CurrentLoginInfo.RoleName;
        }
    }
}
