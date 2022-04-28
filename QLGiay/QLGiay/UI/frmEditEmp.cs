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
    public partial class frmEditEmp : Form
    {
        //private string SqlString, Role = WorkingContext.Instance.CurrentLoginInfo.RoleName;
        //private DataTable dt;
        private string SqlString;
        private int id;
        private string name;
        private string birth;
        private string address;
        private string phone;
        private float salary;
        private string role;
        private int idBranch;
        private int CurrentbranchID = WorkingContext.Instance.CurrentBranchId, idBranchSelected;

        

        public frmEditEmp(DataRow row, int selectedidbranch)
        {
            InitializeComponent();
            //this.idEmp = idemp;
            this.id = Int32.Parse(row[0].ToString());
            this.name = row[1].ToString();
            this.birth = row[2].ToString();
            this.address = row[3].ToString();
            this.phone = row[4].ToString();
            this.salary = float.Parse(row[5].ToString());
            this.role = row[6].ToString();
            this.idBranch = Int32.Parse(row[7].ToString());

            this.idBranchSelected = selectedidbranch;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditEmp_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=BUNSBOF\SERVER1;Initial Catalog=QLUniqlo;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select id, name from Branch", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            da.Fill(table1);

            DataRow itemrow = table1.NewRow();
            itemrow[1] = "Đổi Chi Nhánh ?";
            table1.Rows.InsertAt(itemrow, 0);
            cbbBranch.DataSource = table1;
            cbbBranch.DisplayMember = "name";
            cbbBranch.ValueMember = "id";
            conn.Close();

            txtName.Text = name;
            txtBirth.Text = birth;
            txtaddress.Text = address;
            txtPhone.Text = phone;
            txtSalary.Text = salary.ToString();
            txtRole.Text = role;
            cbbBranch.SelectedIndex = idBranch;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cbbBranch.SelectedIndex == WorkingContext.Instance.CurrentBranchId)
            {
                if (txtName.Text != name || txtBirth.Text != birth || txtaddress.Text != address || txtPhone.Text != phone || txtSalary.Text != salary.ToString() || txtRole.Text != role || cbbBranch.SelectedIndex != idBranch)
                {
                    SqlString = String.Format("exec sp_updateEmp '{0}', '{1}', '{2}', {3}, {4}, {5}, {6}", this.id, txtName.Text, txtPhone.Text, txtaddress.Text, txtSalary.Text, txtRole.Text, cbbBranch.SelectedIndex);
                    ReturnNum(WorkingContext.Instance.CurrentBranchId, SqlString);
                } 
            }
            else if (cbbBranch.SelectedIndex != WorkingContext.Instance.CurrentBranchId)
            {
                if (txtName.Text != name || txtBirth.Text != birth || txtaddress.Text != address || txtPhone.Text != phone || txtSalary.Text != salary.ToString() || txtRole.Text != role || cbbBranch.SelectedIndex != idBranch)
                {
                    SqlString = String.Format("exec sp_updateEmp2 '{0}', '{1}', '{2}', {3}, {4}, {5}, {6}", txtName.Text, txtBirth.Text, txtaddress.Text, txtPhone.Text, float.Parse(txtSalary.ToString()), txtRole.Text, cbbBranch.SelectedIndex);
                    ReturnNum(cbbBranch.SelectedIndex, SqlString);
                }
            }

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
    }
}
