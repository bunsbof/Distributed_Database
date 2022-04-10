using QLGiay.Utilities;
using QLUniqlo.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLGiay.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string branch, loginName, password;
            if (txtUser.Text == "" || txtPass.Text == "") lblMessage.Text = "Vui lòng nhập thông tin đăng nhập";
            if (cbbBranch.Text == cbbBranch.Items[0].ToString())
            {
                lblMessage.Text = "Vui lòng chọn chi nhánh";
                return;
            }

            branch = cbbBranch.Text;
            int branchId = cbbBranch.SelectedIndex + 1;
            loginName = txtUser.Text;
            password = txtPass.Text;

            WorkingContext.Instance.CurrentBranch = branch;
            WorkingContext.Instance.CurrentLoginName = loginName;
            WorkingContext.Instance.CurrentBranchId = branchId;

            var connectionName = string.Format("Branch{0}", branchId);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString; //CHỖ NÀY

            connectionString = string.Format(connectionString, loginName, password);
            WorkingContext.Instance.Initialize(connectionString);

            try
            {
                var dbcontext = WorkingContext.Instance._dbcontext;
                var loginInfo = dbcontext.Database.SqlQuery<LoginInfo>("exec sp_GetLoginInfo @p0", loginName).FirstOrDefault();
                WorkingContext.Instance.CurrentLoginInfo = loginInfo;
                frmMain frmMain = new frmMain();
                frmMain.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sai thông tin đăng nhập \r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=BUNSBOF\SERVER1;Initial Catalog=QLUniqlo;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select id, name from Branch", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            da.Fill(table1);

            DataRow itemrow = table1.NewRow();
            //itemrow[1] = "Select Branch";
            //table1.Rows.InsertAt(itemrow, 0);
            cbbBranch.DataSource = table1;
            cbbBranch.DisplayMember = "name";
            cbbBranch.ValueMember = "id";
        }

        private void cbbBranch_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
