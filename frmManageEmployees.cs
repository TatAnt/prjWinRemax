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
    public partial class frmManageEmployees : Form
    {
        public frmManageEmployees()
        {
            InitializeComponent();
        }
        DataSet mySet;
        SqlDataAdapter agentAdapter, adminAdapter;
        SqlCommandBuilder myBuilder;
        SqlConnection myCon;
        DataTable tabAgents, tabAdmins;
        SqlCommand myCmd, myCmd1;

        int position = 0;
        string mode = "";
        string roleId;
        long employeeId;
        private void frmManageEmployees_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();
            clsGlobalVaiables.mySet = new DataSet();
            myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBRemax;Integrated Security=True");
            myCon.Open();


            myCmd = new SqlCommand("SELECT * FROM Agents", myCon);
            agentAdapter = new SqlDataAdapter(myCmd);
            agentAdapter.Fill(mySet, "Agents");
            tabAgents = mySet.Tables["Agents"];
            roleId = lblRoleId.Text;
            employeeId = Convert.ToInt64(lblUser.Text);
            if (roleId == "1")
            {
                myCmd1 = new SqlCommand("SELECT FullName FROM  Agents WHERE AgentId = '" + employeeId + "'", myCon);
                adminAdapter = new SqlDataAdapter(myCmd1);
                adminAdapter.Fill(mySet, "Admins");
                tabAdmins = mySet.Tables["Admins"];
                lblEmpName.Text = tabAdmins.Rows[0]["FullName"].ToString();
                lblJobTitle.Text = "Admin";
            }
            //gridAgents.DataSource = tabAgents;
            DisplayAgent(0);
            foreach (DataRow myRow in tabAgents.Rows)
            {
                cboAgentType.Items.Add(myRow["RealEstateType"].ToString());
            }

            var agentName = from agent in tabAgents.AsEnumerable()
                            select new { AgentName = agent.Field<string>("FullName") };

            lstAgents.DisplayMember = "AgentName";
            lstAgents.DataSource = agentName.ToList();

            ActivateButtons(true, true, true, false, false, true, true);
        }


        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function for navigating throught the [Agents] -> BUTTONS(first, next, previous, last)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void DisplayAgent(int index)
        {
            txtEmpFullName.Text = tabAgents.Rows[index]["FullName"].ToString();
            txtPhone.Text = tabAgents.Rows[index]["Phone"].ToString();
            txtEmail.Text = tabAgents.Rows[index]["Email"].ToString();
            txtAddress.Text = tabAgents.Rows[index]["Location"].ToString();
            cboAgentType.Text = tabAgents.Rows[index]["RealEstateType"].ToString();
            txtStatus.Text = tabAgents.Rows[index]["Status"].ToString();
            pickHireDate.Value = Convert.ToDateTime(tabAgents.Rows[index]["HireDate"]);

            int rowNumber = index + 1;
            lblInfo.Text = "Agent " + rowNumber + " on a total of " + tabAgents.Rows.Count;
        }



        private void cboAgentType_KeyPress(object sender, KeyPressEventArgs e)
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
            txtEmpFullName.Focus();
            cboAgentType.Text = "";
            lblInfo.Text = "----- ADDING a NEW AGENT -----";
            ActivateButtons(false, false, false, true, true, false, false);
        }




        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button UPDATE
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            mode = "update";
            txtEmpFullName.Focus();
            lblInfo.Text = "----- EDITTING CURRENT AGENT -----";
            ActivateButtons(false, false, false, true, true, false, false);
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button SAVE
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow myRow;
            if (mode == "add")
            {
                myRow = tabAgents.NewRow();

                myRow["FullName"] = txtEmpFullName.Text;
                myRow["Phone"] = txtPhone.Text;
                myRow["Email"] = txtEmail.Text;
                myRow["RealEstateType"] = cboAgentType.Text;
                myRow["Status"] = txtStatus.Text;
                myRow["HireDate"] = pickHireDate.Value;
                myRow["Location"] = txtAddress.Text;
                tabAgents.Rows.Add(myRow);

                myBuilder = new SqlCommandBuilder(agentAdapter);
                agentAdapter.Update(mySet, "Agents");
                mySet.Tables.Remove("Agents");
                agentAdapter.Fill(mySet, "Agents");
                position = tabAgents.Rows.Count - 1;
            }
            else if (mode == "update")
            {
                //edit the current datarow
                myRow = tabAgents.Rows[position];
                myRow["FullName"] = txtEmpFullName.Text;
                myRow["Phone"] = txtPhone.Text;
                myRow["Email"] = txtEmail.Text;
                myRow["RealEstateType"] = cboAgentType.Text;
                myRow["Status"] = txtStatus.Text;
                myRow["HireDate"] = pickHireDate.Value;
                myRow["Location"] = txtAddress.Text;

                tabAgents.Rows.Add(myRow);

                myBuilder = new SqlCommandBuilder(agentAdapter);
                agentAdapter.Update(mySet, "Agents");
                mySet.Tables.Remove("Agents");
                agentAdapter.Fill(mySet, "Agents");
            }
            mode = "";
            DisplayAgent(position);
            // displayEmployee(currentIndex);

            ActivateButtons(true, true, true, false, false, true, true);
        
        }
    


        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button DELETE (Client)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Agent?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tabAgents.Rows[position].Delete();
                myBuilder = new SqlCommandBuilder(agentAdapter);
                agentAdapter.Update(tabAgents);
                position = 0;
                DisplayAgent(0);

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
            cboAgentType.Text = "";
            txtEmpFullName.Focus();
            ActivateButtons(true, true, true, false, false, true, true);
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button CLOSE
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnClose_Click(object sender, EventArgs e)
        {
            string question = "Do you want to close this Remax Agents Management Form?";
            string title = "Form Closing Warning";

            if (MessageBox.Show(question, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Hide();
                // Application.Exit();
            }
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button First (Agent)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnFirst_Click(object sender, EventArgs e)
        {
                if (tabAgents.Rows.Count > 0)
                {
                    position = 0;
                    DisplayAgent(position);
                }
        }

        private void lstAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = lstAgents.Text.ToString();
            var AgentToFind = from comp in tabAgents.AsEnumerable()
                                where comp.Field<string>("FullName") == selectedName
                                select comp;

            txtEmpFullName.Text = AgentToFind.ElementAt(0)["FullName"].ToString(); 
            txtPhone.Text = AgentToFind.ElementAt(0)["Phone"].ToString();
            txtEmail.Text = AgentToFind.ElementAt(0)["Email"].ToString();
            cboAgentType.Text = AgentToFind.ElementAt(0)["RealEstateType"].ToString();
            txtStatus.Text = AgentToFind.ElementAt(0)["Status"].ToString();
            pickHireDate.Value = Convert.ToDateTime(AgentToFind.ElementAt(0)["HireDate"]);
            txtAddress.Text = AgentToFind.ElementAt(0)["Location"].ToString();
      
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button Previous (Client)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnPrevious_Click(object sender, EventArgs e)
        {
                position--;
                if (position >= 0)
                {
                    DisplayAgent(position);
                }
                else
                {
                    MessageBox.Show("This is the first Agent in the list");
                }
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button Next (Agent)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnNext_Click(object sender, EventArgs e)
        {
                position++;
                if (position <= (tabAgents.Rows.Count - 1))
                {
                    DisplayAgent(position);
                }
                else
                {
                    MessageBox.Show("This is the last Agent in the list");
                }
            
        }
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Button Last (Agent)
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnLast_Click(object sender, EventArgs e)
        {
                position = tabAgents.Rows.Count - 1;
                DisplayAgent(position);
            
        }
    }
}
