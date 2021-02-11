using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace prjWinRemaxTaianaAntokhine
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection myCon;
        SqlCommand myCmd;
        SqlDataAdapter myAdapter, userAdapter;
        DataSet mySet;
        DataTable tabUsers, allUsers;
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            int role;
            

            if (txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter username and password!");
            }
            mySet = new DataSet();
            myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBRemax;Integrated Security=True");
            myCon.Open();
            myCmd = new SqlCommand("SELECT * FROM Users WHERE UserName = '" + userName + "' AND Password = '" + password + "'", myCon);
            myAdapter = new SqlDataAdapter(myCmd);
            myAdapter.Fill(mySet, "Users");
            tabUsers = mySet.Tables["Users"];
            if (tabUsers.Rows.Count > 0)
            {
                MessageBox.Show("Welcome back " + userName + " !");

                this.Hide();
                frmManagement fm = new frmManagement();
                frmManageClient fmCl = new frmManageClient();
                foreach (DataRow myRow in tabUsers.Rows)
                {
                 
                    fm.lblRoleId.Text = myRow["RoleId"].ToString();
                    fm.lblId.Text = myRow["EmployeeId"].ToString();
                
             

                }
                role = Convert.ToInt32(tabUsers.Rows[0]["RoleId"]);
               
                switch (role)
                {
                    case 0:
                        fm.Show();
                        fm.btnManageEmployees.Hide();
                        fm.lblRoleId.Text = role.ToString();
                        break;
                    case 1:
                    
                        fm.Show();
                        fm.lblRoleId.Text = role.ToString();
                        break;
                }
            }
            else
            {
                lblError.Text = "Incorrect UserName or Password!";
                lblError.Visible = true;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
          //
        }
    }
}
