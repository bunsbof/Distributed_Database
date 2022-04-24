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
    public partial class frmEmployee : Form
    {
        private DataTable dt;
        private int Branch = WorkingContext.Instance.CurrentBranchId;
        string sqlString;
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void DGVReturn(int BranchTran, string SqlString, DataGridView dgv)
        {
            dt = new DataTable();
            var connectionName = string.Format("Branch{0}", BranchTran);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, "sa", "123456");
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(SqlString, connection);
            sda.Fill(dt);
            dgv.DataSource = dt;
            connection.Close();
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

        private void cbbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvEmp.DefaultCellStyle.ForeColor = Color.Black;
            dgvEmp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            if (WorkingContext.Instance.CurrentLoginInfo.RoleName == "GIAMDOC")
            {
                if (cbbBranch.SelectedIndex == 0)
                {
                    sqlString = "select id as 'Số thứ tự', name as 'Tên', birthday as 'Ngày Sinh', address as 'Địa Chỉ', phone as 'Số điện thoại', salary as 'Lương', role as 'Chức vụ', id_branch as 'Số chi nhánh' from Employees union select id as 'Số thứ tự', name as 'Tên', birthday as 'Ngày Sinh', address as 'Địa Chỉ', phone as 'Số điện thoại', salary as 'Lương', role as 'Chức vụ', id_branch as 'Số chi nhánh' from LINK.QLUniqlo.[dbo].Employees";
                    DGVReturn(Branch, sqlString, dgvEmp);
                }
                else if (cbbBranch.SelectedIndex == Branch)
                {
                    sqlString = "select id as 'Số thứ tự', name as 'Tên', birthday as 'Ngày Sinh', address as 'Địa Chỉ', phone as 'Số điện thoại', salary as 'Lương', role as 'Chức vụ', id_branch as 'Số chi nhánh' from Employees";
                    DGVReturn(Branch, sqlString, dgvEmp);
                }
                else if (cbbBranch.SelectedIndex != Branch)
                {
                    //Branch = cbbBranch.SelectedIndex;
                    sqlString = "select id as 'Số thứ tự', name as 'Tên', birthday as 'Ngày Sinh', address as 'Địa Chỉ', phone as 'Số điện thoại', salary as 'Lương', role as 'Chức vụ', id_branch as 'Số chi nhánh' from LINK.QLUniqlo.[dbo].Employees";
                    DGVReturn(Branch, sqlString, dgvEmp);
                }
            }
            
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            //WorkingContext.Instance.CurrentLoginInfo.RoleName;
            if (WorkingContext.Instance.CurrentLoginInfo.RoleName == "GIAMDOC")
            {
                SqlConnection conn = new SqlConnection(@"Data Source=BUNSBOF\SERVER1;Initial Catalog=QLUniqlo;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select id, name from Branch", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable table1 = new DataTable();
                da.Fill(table1);

                DataRow itemrow = table1.NewRow();
                itemrow[1] = "Tất cả";
                table1.Rows.InsertAt(itemrow, 0);
                cbbBranch.DataSource = table1;
                cbbBranch.DisplayMember = "name";
                cbbBranch.ValueMember = "id";
            }else
            {
                dgvEmp.DefaultCellStyle.ForeColor = Color.Black;
                dgvEmp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvEmp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                cbbBranch.Text = WorkingContext.Instance.CurrentBranch;
                sqlString = "select id as 'Số thứ tự', name as 'Tên', birthday as 'Ngày Sinh', address as 'Địa Chỉ', phone as 'Số điện thoại', salary as 'Lương', role as 'Chức vụ', id_branch as 'Số chi nhánh' from Employees";
                DGVReturn(Branch, sqlString, dgvEmp);
            }


            //cbbBranch.Text = WorkingContext.Instance.CurrentBranch;
        }
    }
}
