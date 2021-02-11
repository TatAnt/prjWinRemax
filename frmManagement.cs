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
    public partial class frmManagement : Form
    {
        public frmManagement()
        {
            InitializeComponent();
        }


        private void frmManagement_Load(object sender, EventArgs e)
        {
            if (lblRoleId.Text == "0")
            {
                btnManageEmployees.Hide();
            }
        }
        private void btnManageClients_Click(object sender, EventArgs e)
        {
            frmManageClient fmCl = new frmManageClient();
            fmCl.lblUser.Text = this.lblId.Text;
            fmCl.lblRoleId.Text = this.lblRoleId.Text;
            fmCl.Show();
            //this.Hide();
            //frmManageClient fmcl = new frmManageClient();
            //fmcl.MdiParent = this;
            //fmcl.Show();
        }

      

        private void btnManageHouses_Click(object sender, EventArgs e)
        {
            frmManageHouse fmhouse = new frmManageHouse();
            fmhouse.lblUser.Text = this.lblId.Text;
            fmhouse.lblRoleId.Text = this.lblRoleId.Text;
            fmhouse.Show();
        }

        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            frmManageEmployees fme = new frmManageEmployees();
            fme.lblUser.Text = this.lblId.Text;
            fme.lblRoleId.Text = this.lblRoleId.Text;
            fme.Show();
        }
    }
}
