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
    public partial class frmManageClient : Form
    {
        public frmManageClient()
        {
            InitializeComponent();
        }


        DataSet mySet;
        SqlDataAdapter clientAdapter, agentAdapter, adminAdapter;
        SqlCommandBuilder myBuilder;
        SqlConnection myCon;
        DataTable tabClients, tabAgents, tabAdmins, tabClientTypes;
        SqlCommand myCmd1, myCmd2, myCmd3, myCmd4;
        int position = 0;
        string mode = "";
        string roleId;
        long employeeId;
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Form Load
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void frmManageClient_Load(object sender, EventArgs e)
        {
            //Form_Load:
            mySet = new DataSet();
            clsGlobalVaiables.mySet = new DataSet();
            myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBRemax;Integrated Security=True");
            myCon.Open();

            SqlCommand myCmd = new SqlCommand("SELECT * FROM Houses", myCon);
            clsGlobalVaiables.adpHouses = new SqlDataAdapter(myCmd);
            clsGlobalVaiables.adpHouses.Fill(clsGlobalVaiables.mySet, "Houses");

            roleId = lblRoleId.Text;
            employeeId = Convert.ToInt64(lblUser.Text);

            switch (roleId)
            {
                case "0":
                    myCmd1 = new SqlCommand("SELECT * FROM Clients WHERE RefAgentId = '" + employeeId + "'", myCon);
                    clientAdapter = new SqlDataAdapter(myCmd1);
                    clientAdapter.Fill(mySet, "Clients");
                    tabClients = mySet.Tables["Clients"];
                    myCmd2 = new SqlCommand("SELECT AgentId, FullName FROM Agents WHERE AgentId = '" + employeeId + "'", myCon);
                    agentAdapter = new SqlDataAdapter(myCmd2);
                    agentAdapter.Fill(mySet, "Agents");
                    tabAgents = mySet.Tables["Agents"];

                    lblEmpName.Text = tabAgents.Rows[0]["FullName"].ToString();
                    lblJobTitle.Text = "Agent";
                    break;
                case "1":
                    myCmd1 = new SqlCommand("SELECT FullName, Phone, Email, Address, ClientType, Status, RefAgentID FROM Clients", myCon);
                    clientAdapter = new SqlDataAdapter(myCmd1);
                    clientAdapter.Fill(mySet, "Clients");
                    tabClients = mySet.Tables["Clients"];
                    myCmd2 = new SqlCommand("SELECT AgentId, FullName FROM Agents", myCon);
                    agentAdapter = new SqlDataAdapter(myCmd2);
                    agentAdapter.Fill(mySet, "Agents");
                    tabAgents = mySet.Tables["Agents"];
                    myCmd3 = new SqlCommand("SELECT FullName FROM  Agents WHERE AgentId = '" + employeeId + "'", myCon);
                    adminAdapter = new SqlDataAdapter(myCmd3);
                    adminAdapter.Fill(mySet, "Admins");
                    tabAdmins = mySet.Tables["Admins"];
                    lblEmpName.Text = tabAdmins.Rows[0]["FullName"].ToString();
                    lblJobTitle.Text = "Admin";

                    break;
            }
            myCmd4 = new SqlCommand("SELECT DISTINCT ClientType FROM Clients", myCon);
            clientAdapter = new SqlDataAdapter(myCmd4);
            clientAdapter.Fill(mySet, "ClientTypes");
            tabClientTypes = mySet.Tables["ClientTypes"];

            foreach (DataRow myRow in tabClientTypes.Rows)
            {
                cboClientType.Items.Add(myRow["ClientType"].ToString());
            }
            foreach (DataRow myRow in tabAgents.Rows)
            {
                cboAgents.Items.Add(myRow["FullName"].ToString());
            }
         
            DisplayClient(0);
            ActivateButtons(true, true, true, false, false, true, true);
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function for navigating throught the [Clients] -> BUTTONS(first, next, previous, last)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void DisplayClient(int index)
        {
            txtClientFullName.Text = tabClients.Rows[index]["FullName"].ToString();
            txtPhone.Text = tabClients.Rows[index]["Phone"].ToString();
            txtEmail.Text = tabClients.Rows[index]["Email"].ToString();
            txtAddress.Text = tabClients.Rows[index]["Address"].ToString();
            cboClientType.Text = tabClients.Rows[index]["ClientType"].ToString();
            txtStatus.Text = tabClients.Rows[index]["Status"].ToString();


           // display Agent Name combobox
            //foreach (DataRow myRow in tabAgents.Rows)
            //{
            //    if (tabClients.Rows[index]["RefAgentId"].ToString() == myRow["AgentId"].ToString())
            //    {
            //        cboAgents.Text = myRow["FullName"].ToString();
            //    }
            //}
            DataColumn[] keys = new DataColumn[1]; //size = 1
            keys[0] = tabAgents.Columns["AgentId"];
            tabAgents.PrimaryKey = keys;
            DataRow foundRow = tabAgents.Rows.Find(tabClients.Rows[index]["RefAgentId"]);
            cboAgents.Text = foundRow["FullName"].ToString();


            int rowNumber = index + 1;
            lblInfo.Text = "Client " + rowNumber + " on a total of " + tabClients.Rows.Count;
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function to prevent typing in the combobox
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void cboAgents_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function ACTIVATE BUTTONS to manage buttons
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ActivateButtons(bool add, bool update, bool delete, bool save, bool cancel, bool navigate, bool close)
        {
            btnAdd.Enabled = add;
            btnUpdate.Enabled = update;
            btnDelete.Enabled = delete;
            btnSave.Enabled = save;
            btnCancel.Enabled = cancel;
            btnFirst.Enabled = btnNext.Enabled = btnPrevious.Enabled = btnLast.Enabled = navigate;
            btnClose.Enabled = close;
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button ADD
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            foreach (TextBox txt in Controls.OfType<TextBox>())
            {
                txt.Text = "";
            }
            txtClientFullName.Focus();
            cboAgents.Text = "";
            lblInfo.Text = "----- ADDING a NEW CLIENT -----";
            ActivateButtons(false, false, false, true, true, false, false);
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button UPDATE
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            mode = "update";
            txtClientFullName.Focus();
            lblInfo.Text = "----- EDITTING CURRENT CLIENT -----";
            ActivateButtons(false, false, false, true, true, false, false);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button SAVE
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow myRow;
            string selectedAgent = cboAgents.SelectedItem.ToString();
            if (mode == "add")
            {
                myRow = tabClients.NewRow();

                myRow["FullName"] = txtClientFullName.Text;
                myRow["Phone"] = txtPhone.Text;
                myRow["Email"] = txtEmail.Text;
                myRow["ClientType"] = cboClientType.Text;
                myRow["Status"] = txtStatus.Text;


                DataColumn[] keys = new DataColumn[1];
                keys[0] = tabAgents.Columns["FullName"];
                tabAgents.PrimaryKey = keys;

                DataRow foundRow1 = tabAgents.Rows.Find(selectedAgent);
                myRow["RefAgentId"] = foundRow1["AgentId"];
                tabClients.Rows.Add(myRow);

                myBuilder = new SqlCommandBuilder(clientAdapter);
                clientAdapter.Update(mySet, "Clients");
                mySet.Tables.Remove("Clients");
                clientAdapter.Fill(mySet, "Clients");
                position = tabClients.Rows.Count - 1;
            }
            else if (mode == "update")
            {
                //edit the current datarow
                myRow = tabClients.Rows[position];
                myRow["FullName"] = txtClientFullName.Text;
                myRow["Phone"] = txtPhone.Text;
                myRow["Email"] = txtEmail.Text;
                myRow["ClientType"] = cboClientType.Text;
                myRow["Status"] = txtStatus.Text;
                DataColumn[] keys = new DataColumn[1];
                keys[0] = tabAgents.Columns["FullName"];
                tabAgents.PrimaryKey = keys;

                DataRow foundRow1 = tabAgents.Rows.Find(selectedAgent);
                myRow["RefAgentId"] = foundRow1["AgentId"];
                tabClients.Rows.Add(myRow);

                myBuilder = new SqlCommandBuilder(clientAdapter);
                clientAdapter.Update(mySet, "Clients");
                mySet.Tables.Remove("Clients");
                clientAdapter.Fill(mySet, "Clients");

            }
            mode = "";
            DisplayClient(position);

            ActivateButtons(true, true, true, false, false, true, true);
        }
    

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button DELETE (Client)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Client?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tabClients.Rows[position].Delete();
                myBuilder = new SqlCommandBuilder(clientAdapter);
                clientAdapter.Update(tabClients);
                position = 0;
                DisplayClient(0); //will display the first client

            }
            else
            {
                MessageBox.Show("No changing done");
            }
        }
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button CANCEL
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in Controls.OfType<TextBox>())
            {
                txt.Text = "";
            }
            cboAgents.Text = "";
            cboClientType.Text = "";
            txtClientFullName.Focus();
            ActivateButtons(true, true, true, false, false, true, true);
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button CLOSE
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnClose_Click(object sender, EventArgs e)
        {
            string question = "Do you want to close this Remax Clients Form?";
            string title = "Form Closing Warning";

            if (MessageBox.Show(question, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Hide();
                // Application.Exit();
            }
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button First (Client)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (tabClients.Rows.Count > 0)
            {
                position = 0;
                DisplayClient(position);
            }
        }
  

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button Previous (Client)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            position--;
            if (position >= 0)
            {
                DisplayClient(position);
            }
            else
            {
                MessageBox.Show("This is the first Client in the list");
            }
        }
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button Next (Client)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnNext_Click(object sender, EventArgs e)
        {
            position++;
            if (position <= (tabClients.Rows.Count - 1))
            {
                DisplayClient(position);
            }
            else
            {
                MessageBox.Show("This is the last Client in the list");
            }
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button Last (Client)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnLast_Click(object sender, EventArgs e)
        {
            position = tabClients.Rows.Count - 1;
            DisplayClient(position);
        }

    }
}
