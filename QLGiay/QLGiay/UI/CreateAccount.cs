using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLUniqlo.UI
{
    public partial class CreateAccount : Form
    {
        private int id;
        private string sqlstring;
        private int selectedBranch;
        private int idBranch;
        public CreateAccount(DataRow row, int selectedBranch)
        {
            this.id = Int32.Parse(row[0].ToString());
            this.idBranch = Int32.Parse(row[7].ToString());
            this.selectedBranch = selectedBranch;
            InitializeComponent();
        }

        private void ReturnNum(int Branch, string SqlString)
        {
            var connectionName = string.Format("Branch{0}", Branch);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, "sa", "123456");
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            var command = new SqlCommand(SqlString, connection);
            command.Connection = connection;
            command.Connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtId.Text = this.id.ToString();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) || !string.IsNullOrEmpty(txtPassword.Text) || !string.IsNullOrEmpty(txtRole.Text))
            {
                sqlstring = String.Format("exec sp_TaoTaiKhoan {0}, {1}, {2}, {3}", txtUsername.Text, txtPassword.Text, txtId.Text, txtRole.Text);
                ReturnNum(idBranch, sqlstring);
                this.Close();
            }
        }
    }
}
