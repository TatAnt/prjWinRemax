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
    public partial class frmManageHouse : Form
    {
        public frmManageHouse()
        {
            InitializeComponent();
        }
        DataSet mySet;
        SqlDataAdapter houseAdapter, agentAdapter, clientAdapter, adminAdapter, typeAdapter, roofAdapter, statusAdapter;
        SqlCommandBuilder myBuilder;
        SqlConnection myCon;
        DataTable tabClients, tabAgents, tabAdmins, tabHouses, tabTypes, tabRoof, tabStatus;
        SqlCommand myCmd1, myCmd2, myCmd3, myCmd4;
        int position = 0;
        string mode = "";

        string roleId;

        long employeeId;

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Form Load
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void frmManageHouse_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();
            myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBRemax;Integrated Security=True");
            myCon.Open();
            roleId = lblRoleId.Text;
            employeeId = Convert.ToInt64(lblUser.Text);
            switch (roleId)
            {
                case "0":
                    myCmd1 = new SqlCommand("SELECT * FROM Houses WHERE RefAgentId = '" + employeeId + "'", myCon);
                    houseAdapter = new SqlDataAdapter(myCmd1);
                    houseAdapter.Fill(mySet, "Houses");
                    tabHouses = mySet.Tables["Houses"];
                    //=================================================================================================================
                    myCmd2 = new SqlCommand("SELECT AgentId, FullName FROM Agents WHERE AgentId = '" + employeeId + "'", myCon);
                    agentAdapter = new SqlDataAdapter(myCmd2);
                    agentAdapter.Fill(mySet, "Agents");
                    tabAgents = mySet.Tables["Agents"];
                    //=================================================================================================================
                    myCmd2 = new SqlCommand("SELECT ClientId, FullName, RefAgentId FROM Clients", myCon);
                    clientAdapter = new SqlDataAdapter(myCmd2);
                    clientAdapter.Fill(mySet, "Clients");
                    tabClients = mySet.Tables["Clients"];

                    lblEmpName.Text = tabAgents.Rows[0]["FullName"].ToString();
                    lblJobTitle.Text = "Agent";
                    break;
                case "1":
                    myCmd1 = new SqlCommand("SELECT * FROM Houses", myCon);
                    houseAdapter = new SqlDataAdapter(myCmd1);
                    houseAdapter.Fill(mySet, "Houses");
                    tabHouses = mySet.Tables["Houses"];
                    //=================================================================================================================
                    myCmd2 = new SqlCommand("SELECT AgentId, FullName FROM Agents", myCon);
                    agentAdapter = new SqlDataAdapter(myCmd2);
                    agentAdapter.Fill(mySet, "Agents");
                    tabAgents = mySet.Tables["Agents"];
                    //=================================================================================================================
                    myCmd2 = new SqlCommand("SELECT ClientId, FullName, RefAgentId FROM Clients", myCon);
                    clientAdapter = new SqlDataAdapter(myCmd2);
                    clientAdapter.Fill(mySet, "Clients");
                    tabClients = mySet.Tables["Clients"];
                    //=================================================================================================================
                    myCmd3 = new SqlCommand("SELECT FullName FROM  Agents WHERE AgentId = '" + employeeId + "'", myCon);
                    adminAdapter = new SqlDataAdapter(myCmd3);
                    adminAdapter.Fill(mySet, "Admins");
                    tabAdmins = mySet.Tables["Admins"];
                    lblEmpName.Text = tabAdmins.Rows[0]["FullName"].ToString();
                    lblJobTitle.Text = "Admin";
                    break;
            }
                    myCmd4 = new SqlCommand("SELECT DISTINCT HouseType FROM Houses", myCon);
                    typeAdapter = new SqlDataAdapter(myCmd4);
                    typeAdapter.Fill(mySet, "Types");
                    tabTypes = mySet.Tables["Types"];
                    foreach (DataRow myRow in tabTypes.Rows)
                    {
                         cboHouseType.Items.Add(myRow["HouseType"].ToString());
                      }
            myCmd4 = new SqlCommand("SELECT DISTINCT RoofType FROM Houses", myCon);
            roofAdapter = new SqlDataAdapter(myCmd4);
            roofAdapter.Fill(mySet, "Roof");
            tabRoof = mySet.Tables["Roof"];
            foreach (DataRow myRow in tabRoof.Rows)
            {
                cboRoofType.Items.Add(myRow["RoofType"].ToString());
            }
            myCmd4 = new SqlCommand("SELECT DISTINCT Status FROM Houses", myCon);
            statusAdapter = new SqlDataAdapter(myCmd4);
            statusAdapter.Fill(mySet, "Status");
            tabStatus = mySet.Tables["Status"];
            foreach (DataRow myRow in tabStatus.Rows)
            {
                cboStatus.Items.Add(myRow["Status"].ToString());
            }
            foreach (DataRow myRow in tabAgents.Rows)
            {
                cboAgentName.Items.Add(myRow["FullName"].ToString());
            }
            foreach (DataRow myRow in tabClients.Rows)
            {
                cboClientName.Items.Add(myRow["FullName"].ToString());
            }

            DisplayHouse(0);
            ActivateButtons(true, true, true, false, false, true, true);
           // }
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function for navigating throught the [Houses] -> BUTTONS(first, next, previous, last)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void DisplayHouse(int index)
        {
            cboHouseType.Text = tabHouses.Rows[index]["HouseType"].ToString();
            txtLocation.Text= tabHouses.Rows[index]["Location"].ToString();
            txtPrice.Text = tabHouses.Rows[index]["Price"].ToString();
            txtAge.Text = tabHouses.Rows[index]["Age"].ToString();
            txtSpace.Text = tabHouses.Rows[index]["LivingSpace"].ToString();
            txtBedroom.Text = tabHouses.Rows[index]["Bedroom"].ToString();
            txtBathroom.Text = tabHouses.Rows[index]["Bathroom"].ToString();
            txtGarage.Text = tabHouses.Rows[index]["Garage"].ToString();
            cboRoofType.Text = tabHouses.Rows[index]["RoofType"].ToString();
            cboStatus.Text = tabHouses.Rows[index]["Status"].ToString();
            bool p = Convert.ToBoolean(tabHouses.Rows[index]["Pool"].ToString());
            chkPool.Checked = (p == true) ? true : false;
            bool b = Convert.ToBoolean(tabHouses.Rows[index]["Basement"].ToString());
            chkBasement.Checked = (b == true) ? true : false;

            //display Agent Name combobox
            foreach (DataRow myRow in tabAgents.Rows)
            {
                if (tabHouses.Rows[index]["RefAgentId"].ToString() == myRow["AgentId"].ToString())
                {
                    cboAgentName.Text = myRow["FullName"].ToString();
                }
            }
            DataColumn[] keys = new DataColumn[1]; //size = 1
            keys[0] = tabClients.Columns["ClientId"];
            tabClients.PrimaryKey = keys;
            DataRow foundRow = tabClients.Rows.Find(tabHouses.Rows[index]["RefClientId"]);
            //display Client Name combobox
            cboClientName.Text = foundRow["FullName"].ToString();

            int rowNumber = index + 1;
            lblInfo.Text = "House " + rowNumber + " on a total of " + tabHouses.Rows.Count;
        }
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function checks if a House has a Pool
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool CheckPool(int index)
        {
            while (tabHouses.Rows[index]["Pool"].ToString() == "True")
            {
                return chkPool.Checked = true;
            }
            return false;
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function checks if a Basement is finished in a House
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool CheckBasement(int index)
        {
            while (tabHouses.Rows[index]["Basement"].ToString() == "True")
            {
                return chkBasement.Checked = true;
            }
            return false;
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
            cboHouseType.Focus();
            cboClientName.Text = cboAgentName.Text = cboRoofType.Text = "";
           
            lblInfo.Text = "----- ADDING a NEW HOUSE -----";
            ActivateButtons(false, false, false, true, true, false, false);
            
        }
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button UPDATE
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnUpdate_Click(object sender, EventArgs e)
        {
                mode = "update";
                cboHouseType.Focus();
                lblInfo.Text = "----- EDITTING CURRENT HOUSE -----";
                ActivateButtons(false, false, false, true, true, false, false);
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button SAVE
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        private void btnSave_Click(object sender, EventArgs e)
        {
                DataRow myRow;
                string selectedAgent = cboAgentName.SelectedItem.ToString();
                string selectedClient = cboClientName.SelectedItem.ToString();
            if (mode == "add")
            {
                myRow = tabHouses.NewRow();
                myRow["HouseType"] = cboHouseType.Text;
                myRow["Location"] = txtLocation.Text;
                myRow["Price"] = txtPrice.Text;
                myRow["Age"] = txtAge.Text;
                myRow["LivingSpace"] = txtSpace.Text;
                myRow["Bedroom"] = txtBedroom.Text;
                myRow["Bathroom"] = txtBathroom.Text;
                myRow["Garage"] = txtGarage.Text;
                myRow["RoofType"] = cboRoofType.Text;
                myRow["Status"] = cboStatus.Text;
                bool pool = (chkPool.Checked == true) ? true : false;
                myRow["Pool"] = pool;
                bool basement = (chkBasement.Checked == true) ? true : false;
                myRow["Pool"] = basement;
                //insert RefAgentId into table Houses instead of AgentName
                DataColumn[] keys1 = new DataColumn[1];
                keys1[0] = tabAgents.Columns["FullName"];
                tabAgents.PrimaryKey = keys1;
                DataRow foundRow1 = tabAgents.Rows.Find(selectedAgent);
                myRow["RefAgentId"] = foundRow1["AgentId"];
                tabHouses.Rows.Add(myRow);
                //insert RefClientId into table Houses instead of ClientName
                DataColumn[] keys2 = new DataColumn[1];
                keys2[0] = tabClients.Columns["FullName"];
                tabClients.PrimaryKey = keys2;
                DataRow foundRow2 = tabClients.Rows.Find(selectedClient);
                myRow["RefClientId"] = foundRow2["ClientId"];
                tabHouses.Rows.Add(myRow);


                myBuilder = new SqlCommandBuilder(houseAdapter);
                houseAdapter.Update(mySet, "Houses");
                mySet.Tables.Remove("Houses");
                houseAdapter.Fill(mySet, "Houses");
                position = tabHouses.Rows.Count - 1;
            }
            else if (mode == "update")
            {
                //edit the current datarow
                myRow = tabClients.Rows[position];
                myRow["HouseType"] = cboHouseType.Text;
                myRow["Location"] = txtLocation.Text;
                myRow["Price"] = txtPrice.Text;
                myRow["Age"] = txtAge.Text;
                myRow["LivingSpace"] = txtSpace.Text;
                myRow["Bedroom"] = txtBedroom.Text;
                myRow["Bathroom"] = txtBathroom.Text;
                myRow["Garage"] = txtGarage.Text;
                myRow["RoofType"] = cboRoofType.Text;
                myRow["Status"] = cboStatus.Text;
                bool pool = (chkPool.Checked == true) ? true : false;
                myRow["Pool"] = pool;
                bool basement = (chkBasement.Checked == true) ? true : false;
                myRow["Pool"] = basement;
                //insert RefAgentId into table Houses instead of AgentName
                DataColumn[] keys1 = new DataColumn[1];
                keys1[0] = tabAgents.Columns["FullName"];
                tabAgents.PrimaryKey = keys1;
                DataRow foundRow1 = tabAgents.Rows.Find(selectedAgent);
                myRow["RefAgentId"] = foundRow1["AgentId"];
                tabHouses.Rows.Add(myRow);
                //insert RefClientId into table Houses instead of ClientName
                DataColumn[] keys2 = new DataColumn[1];
                keys2[0] = tabClients.Columns["FullName"];
                tabClients.PrimaryKey = keys2;
                DataRow foundRow2 = tabClients.Rows.Find(selectedClient);
                myRow["RefClientId"] = foundRow2["ClientId"];
                tabHouses.Rows.Add(myRow);

                myBuilder = new SqlCommandBuilder(houseAdapter);
                houseAdapter.Update(mySet, "Houses");
                mySet.Tables.Remove("Houses");
                houseAdapter.Fill(mySet, "Houses");
            }
  
                mode = "";
                DisplayHouse(position);

                ActivateButtons(true, true, true, false, false, true, true);
                
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button DELETE (Client)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this House?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tabHouses.Rows[position].Delete();
                myBuilder = new SqlCommandBuilder(houseAdapter);
                houseAdapter.Update(tabHouses);
                position = 0;
                DisplayHouse(0);
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
                cboHouseType.Text = "";
                cboRoofType.Text = "";
                cboClientName.Text = "";
                cboAgentName.Text = "";
                cboHouseType.Focus();
                ActivateButtons(true, true, true, false, false, true, true);
        }
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button CLOSE
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnClose_Click(object sender, EventArgs e)
        {
            string question = "Do you want to close this Remax Houses Form?";
            string title = "Form Closing Warning";

            if (MessageBox.Show(question, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Hide();
                // Application.Exit();
            }
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button First (House)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnFirst_Click(object sender, EventArgs e)
        {
                if (tabHouses.Rows.Count > 0)
                {
                    position = 0;
                    DisplayHouse(position);
                }
        }



        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button Previous (House)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnPrevious_Click(object sender, EventArgs e)
        {
                position--;
                if (position >= 0)
                {
                    DisplayHouse(position);
                }
                else
                {
                    MessageBox.Show("This is the first House in the list");
                }
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button Next (House)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnNext_Click(object sender, EventArgs e)
        {
                position++;
                if (position <= (tabHouses.Rows.Count - 1))
                {
                    DisplayHouse(position);
                }
                else
                {
                    MessageBox.Show("This is the last House in the list");
                }
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button Last (House)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnLast_Click(object sender, EventArgs e)
        {
                position = tabHouses.Rows.Count - 1;
                DisplayHouse(position);
        }

    }
}
