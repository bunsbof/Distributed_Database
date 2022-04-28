using QLGiay.Utilities;
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
    public partial class frmAddEmp : Form
    {
        int phone;
        float salary;
        int branch;
        string sqlString;

        public frmAddEmp()
        {
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

        private void frmAddEmp_Load(object sender, EventArgs e)
        {
            if (WorkingContext.Instance.CurrentLoginInfo.RoleName == "GIAMDOC")
            {
                SqlConnection conn = new SqlConnection(@"Data Source=BUNSBOF\SERVER1;Initial Catalog=QLUniqlo;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select id, name from Branch", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable table1 = new DataTable();
                da.Fill(table1);

                DataRow itemrow = table1.NewRow();
                itemrow[1] = "Chọn chi nhánh giùm";
                table1.Rows.InsertAt(itemrow, 0);
                cbbBranch.DataSource = table1;
                cbbBranch.DisplayMember = "name";
                cbbBranch.ValueMember = "id";
            } else if(WorkingContext.Instance.CurrentLoginInfo.RoleName == "QLCHINHANH")
            {
                cbbBranch.Items.Clear();
                cbbBranch.Items.Add(WorkingContext.Instance.CurrentBranch);
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cbbBranch.SelectedIndex != 0)
            {
                if (!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtBirth.Text) || !string.IsNullOrEmpty(txtaddress.Text) || int.TryParse(txtPhone.Text, out phone) || float.TryParse(txtSalary.Text, out salary) || !string.IsNullOrEmpty(txtRole.Text))
                {
                    if (WorkingContext.Instance.CurrentBranchId != cbbBranch.SelectedIndex)
                    {
                        int.TryParse(txtPhone.Text, out phone);
                        float.TryParse(txtSalary.Text, out salary);

                        sqlString = String.Format("exec addEmployeeA '{0}', '{1}', '{2}', {3}, {4}, {5}, {6}", txtName.Text, txtBirth.Text, txtaddress.Text, phone, salary, txtRole.Text, cbbBranch.SelectedIndex);
                        ReturnNum(cbbBranch.SelectedIndex, sqlString);
                        sqlString = String.Format("exe sp_TaoTaiKhoan");
                        this.Close();
                    }
                    else
                    {
                        int.TryParse(txtPhone.Text, out phone);
                        float.TryParse(txtSalary.Text, out salary);

                        sqlString = String.Format("exec addEmployee '{0}', '{1}', '{2}', {3}, {4}, {5}, {6}", txtName.Text, txtBirth.Text, txtaddress.Text, phone, salary, txtRole.Text, cbbBranch.SelectedIndex);
                        ReturnNum(cbbBranch.SelectedIndex, sqlString);
                        this.Close();
                    }
                }
            } else if(cbbBranch.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtBirth.Text) || !string.IsNullOrEmpty(txtaddress.Text) || int.TryParse(txtPhone.Text, out phone) || float.TryParse(txtSalary.Text, out salary) || !string.IsNullOrEmpty(txtRole.Text))
                {
                    int.TryParse(txtPhone.Text, out phone);
                    float.TryParse(txtSalary.Text, out salary);

                    sqlString = String.Format("exec addEmployee '{0}', '{1}', '{2}', {3}, {4}, {5}, {6}", txtName.Text, txtBirth.Text, txtaddress.Text, phone, salary, txtRole.Text, WorkingContext.Instance.CurrentBranchId);
                    ReturnNum(WorkingContext.Instance.CurrentBranchId, sqlString);
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
