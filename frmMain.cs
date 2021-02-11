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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Form_Load
        ///|//////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void frmMain_Load(object sender, EventArgs e)
        {
            clsGlobalVaiables.mySet = new DataSet();
            //SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBRemax;Integrated Security=True");
            SqlConnection myCon = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DBRemax; Integrated Security = True");
          
            myCon.Open();

            //Table Houses from DB
            SqlCommand myCmd = new SqlCommand("SELECT * FROM Houses", myCon);
            clsGlobalVaiables.adpHouses = new SqlDataAdapter(myCmd);
            clsGlobalVaiables.adpHouses.Fill(clsGlobalVaiables.mySet, "Houses");

            //Table Clients from DB
            myCmd = new SqlCommand("SELECT * FROM Clients", myCon);
            clsGlobalVaiables.adpClients = new SqlDataAdapter(myCmd);
            clsGlobalVaiables.adpClients.Fill(clsGlobalVaiables.mySet, "Clients");

            //Table Agents from DB
            myCmd = new SqlCommand("SELECT * FROM Agents", myCon);
            clsGlobalVaiables.adpEmployees = new SqlDataAdapter(myCmd);
            clsGlobalVaiables.adpEmployees.Fill(clsGlobalVaiables.mySet, "Agents");


            myCmd = new SqlCommand("SELECT DISTINCT HouseType FROM Houses", myCon);
            clsGlobalVaiables.adpHouseType = new SqlDataAdapter(myCmd);
            clsGlobalVaiables.adpHouseType.Fill(clsGlobalVaiables.mySet, "HouseTypes");
            


        }


        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|click on Quit
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void mnuQuit_Click(object sender, EventArgs e)
        {
            string info = "Do you want to terminate this program ?";
            string title = "Application Closing Warning";

            if (MessageBox.Show(info, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void mnuSearchHouse_Click(object sender, EventArgs e)
        {
            frmSearchHouse fsh = new frmSearchHouse();
            fsh.MdiParent = this;
            fsh.Show();
        }

        private void mnuSearchAgent_Click(object sender, EventArgs e)
        {
            frmSearchAgent fsa = new frmSearchAgent();
            fsa.MdiParent = this;
            fsa.Show();
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            frmLogin flog = new frmLogin();
            flog.MdiParent = this;
             flog.Show();
        }

       
    }
}
