using QLGiay.Utilities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLUniqlo.UI
{
    public partial class frmEmployee : Form
    {
        private DataTable dt;
        private int Branch = WorkingContext.Instance.CurrentBranchId;
        private int selectedBranch;
        string sqlString;
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void DGVReturn(int BranchTran, string SqlString, DataGridView dgv)
        {
            dgvEmp.DefaultCellStyle.Font = new Font("Candara Light", 16F, GraphicsUnit.Pixel);
            dgvEmp.DefaultCellStyle.ForeColor = Color.Black;
            dgvEmp.DefaultCellStyle.BackColor = Color.White;
            dgvEmp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            
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
            }
            else if (WorkingContext.Instance.CurrentLoginInfo.RoleName == "QLCHINHANH")
            {
                btnEdit.Hide();
                btnDelete.Hide();
                btnCreateAcc.Hide();
                cbbBranch.Text = WorkingContext.Instance.CurrentBranch;
                sqlString = "select id as 'Số thứ tự', name as 'Tên', birthday as 'Ngày Sinh', address as 'Địa Chỉ', phone as 'Số điện thoại', salary as 'Lương', role as 'Chức vụ', id_branch as 'Số chi nhánh' from Employees";
                DGVReturn(Branch, sqlString, dgvEmp);
            }
            else {
                btnAdd.Hide();
                btnEdit.Hide();
                btnDelete.Hide();
                btnCreateAcc.Hide();
                cbbBranch.Text = WorkingContext.Instance.CurrentBranch;
                sqlString = "select id as 'Số thứ tự', name as 'Tên', birthday as 'Ngày Sinh', address as 'Địa Chỉ', phone as 'Số điện thoại', salary as 'Lương', role as 'Chức vụ', id_branch as 'Số chi nhánh' from Employees";
                DGVReturn(Branch, sqlString, dgvEmp);
            }

            //cbbBranch.Text = WorkingContext.Instance.CurrentBranch;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(dgvEmp.Rows[dgvEmp.CurrentRow.Index].Cells[0].Value);
            DataRow row = (dgvEmp.SelectedRows[0].DataBoundItem as DataRowView).Row;
            //MessageBox.Show(row[0].ToString());
            
            frmEditEmp frmEditEmp = new frmEditEmp(row, cbbBranch.SelectedIndex);
            frmEditEmp.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(WorkingContext.Instance.CurrentLoginInfo.RoleName == "GIAMDOC" || WorkingContext.Instance.CurrentLoginInfo.RoleName == "QLCHINHANH")
            {
                frmAddEmp frmAddEmp = new frmAddEmp();
                frmAddEmp.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dgvEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvEmp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            DataRow row = (dgvEmp.SelectedRows[0].DataBoundItem as DataRowView).Row;
            this.selectedBranch = cbbBranch.SelectedIndex;
            CreateAccount emp = new CreateAccount(row, this.selectedBranch);
            emp.ShowDialog();
        }
    }
}
