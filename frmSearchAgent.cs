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
    public partial class frmSearchAgent : Form
    {
        public frmSearchAgent()
        {
            InitializeComponent();
        }
        DataTable tabAgents, tabClients, tabHouses;

            ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///|Form Load
            ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void frmSearchAgent_Load(object sender, EventArgs e)
        {
            tabAgents = clsGlobalVaiables.mySet.Tables["Agents"];
            tabClients = clsGlobalVaiables.mySet.Tables["Clients"];
            tabHouses = clsGlobalVaiables.mySet.Tables["Houses"];
            txtAgentId.Text = "Enter Agent ID";
            cboLanguage.Text = "Any Language";
            cboLocation.Text = "Any Location";
            cboRealEstate.Text = "Any Real Estate Type";

            ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///|Filling combobox with distinct Location
            ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var locations = (from loc in tabAgents.AsEnumerable()
                             select loc["Location"]).Distinct().ToList();
            cboLocation.DataSource = locations;

            ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///|Filling combobox with distinct Language
            ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var languges = (from lang in tabAgents.AsEnumerable()
                             select lang["Language"]).Distinct().ToList();
            cboLanguage.DataSource = languges;

            ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///|Filling combobox with distinct Real Estate Type
            ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var types = (from type in tabAgents.AsEnumerable()
                            select type["RealEstateType"]).Distinct().ToList();
             cboRealEstate.DataSource = types;

            ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///|Filling List with agents names
            ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var agentName = from ag in tabAgents.AsEnumerable()
                            select new {AgentName = ag.Field<string>("FullName")};
           
            //lstAgents.DataSource = agentName.ToList();
            //lstAgents.DisplayMember = "AgentName";
     

        }



        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|BUTTON FindAgent
        ///|////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnFindAgent_Click(object sender, EventArgs e)
        {
            gridAgents.DataSource = null;
           // cboLanguage.Text = "";
            //cboLocation.Text = "";
           // cboRealEstate.Text = "";

            if (chkID.Checked && txtAgentId.Text != null)
            {
                findAgentByID();
            }
            else if (!chkID.Checked && chkLocation.Checked && !chkLanguage.Checked && !chkType.Checked)
            {
                findAgentByLocation();
            }
            else if (!chkID.Checked && !chkLocation.Checked && !chkLanguage.Checked && !chkType.Checked)
            {
                findAllAgents();
            }
            else if (!chkID.Checked && !chkLocation.Checked && chkLanguage.Checked && !chkType.Checked)
            {
                findAgentByLanguage();
            }
            else if (!chkID.Checked && !chkLocation.Checked && !chkLanguage.Checked && chkType.Checked)
            {
                findAgentByRealEstate();
            }
            else if (!chkID.Checked && chkLocation.Checked && chkLanguage.Checked && !chkType.Checked)
            {
                findAgentByLocationLanguage();
            }
            else if (!chkID.Checked && !chkLocation.Checked && chkLanguage.Checked && chkType.Checked)
            {
                findAgentByLanguageType();
            }
            else if (!chkID.Checked && chkLocation.Checked && !chkLanguage.Checked && chkType.Checked)
            {
                findAgentByLocationType();
            }

           
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function Find ALL Agents
        ///|////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void findAllAgents()
        {
            var allAgents = (from agent in tabAgents.AsEnumerable()
                             where agent.Field<int>("RoleId") == 0
                             select agent).CopyToDataTable();
            gridAgents.DataSource = allAgents;
        }

        private void txtAgentId_Enter(object sender, EventArgs e)
        {
            if (txtAgentId.Text == "Enter Agent ID")
            {
                txtAgentId.Text = "";
                txtAgentId.ForeColor = Color.Black;
            }
        }

        private void txtAgentId_Leave(object sender, EventArgs e)
        {
            if (txtAgentId.Text.Trim() == "")
            {

                txtAgentId.Text = "Enter Agent ID";
            }
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function Find Agent By ID
        ///|////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void findAgentByID()
        {
            int a;
            gridAgents.DataSource = null;
            int agentId = Convert.ToInt32(txtAgentId.Text);

            //=============Check if Row exists in DataTable tabAgents======================================================
            var idExists = from agent in tabAgents.AsEnumerable()
                           where agent.Field<int>("AgentId") == Convert.ToInt32(txtAgentId.Text)
                           select agent.Field<int>("AgentId");

            if (!int.TryParse(txtAgentId.Text, out a))
            {
                MessageBox.Show("Please enter valid Agent ID!");
                return;
            }


            if(idExists.Any())
            {
                var agentById = (from agent in tabAgents.AsEnumerable()
                                 where agent.Field<int>("AgentId") == agentId
                                 select agent).CopyToDataTable();
                gridAgents.DataSource = agentById;
                txtAgentId.Text = "";
            }
            else
            {
                MessageBox.Show("Agent with ID " + agentId + " was not found!");
            }
            }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function Find Agent By Location
        ///|////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void findAgentByLocation()
        {
            if (cboLocation.SelectedItem != null)
            {
                var agentByLocation = (from agent in tabAgents.AsEnumerable()
                                 where agent.Field<string>("Location") == cboLocation.SelectedItem.ToString()
                                 select agent).CopyToDataTable();
                gridAgents.DataSource = agentByLocation;
            }
            else
            {
                MessageBox.Show("Please select a Location of Employee");
            }
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function Find Agent By Language
        ///|////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void findAgentByLanguage()
        {
            if (cboLanguage.SelectedItem != null)
            {
                var agentByLanguage = (from agent in tabAgents.AsEnumerable()
                                       where agent.Field<string>("Language") == cboLanguage.SelectedItem.ToString()
                                       select agent).CopyToDataTable();
                gridAgents.DataSource = agentByLanguage;
            }
            else
            {
                MessageBox.Show("Please select a Language of Employee");
            }
        }
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function Find Agent By Location And Language
        ///|////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void findAgentByLocationLanguage()
        {
            if (cboLocation.SelectedItem != null && cboLanguage.SelectedItem != null)
            {
                var agentByLocLanguage = from agent in tabAgents.AsEnumerable()
                                       where agent.Field<string>("Language") == cboLanguage.SelectedItem.ToString()
                                       && agent.Field<string>("Location") == cboLocation.SelectedItem.ToString()
                                       select agent;

                if (agentByLocLanguage.Count<DataRow>() != 0)
                {
                    gridAgents.DataSource = agentByLocLanguage.CopyToDataTable(); ;
                }
                else
                {
                    gridAgents.DataSource = null;
                    string message = "At this moment Agent with selected parameters is not available.\nTry to change yor request.";
                    string title = "Thank you for your request!";
                    DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a Language of Employee");
            }
        }
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function Find Agent By Language and Type
        ///|////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void findAgentByLanguageType()
        {
            if (cboRealEstate.SelectedItem != null && cboLanguage.SelectedItem != null)
            {
                var agentByTypeLanguage = from agent in tabAgents.AsEnumerable()
                                           where agent.Field<string>("Language") == cboLanguage.SelectedItem.ToString()
                                           && agent.Field<string>("RealEstateType") == cboRealEstate.SelectedItem.ToString()
                                           select agent;
                if (agentByTypeLanguage.Count<DataRow>() != 0)
                {
                    gridAgents.DataSource = agentByTypeLanguage.CopyToDataTable(); ;
                }
                else
                {
                    gridAgents.DataSource = null;
                    string message = "At this moment Agent with selected parameters is not available.\nTry to change yor request.";
                    string title = "Thank you for your request!";
                    DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a Language of Employee");
            }
        }
        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function Find Agent By Location and Type
        ///|////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void findAgentByLocationType()
        {
            if (cboRealEstate.SelectedItem != null && cboLocation.SelectedItem != null)
            {
                var agentByLocType = from agent in tabAgents.AsEnumerable()
                                      where agent.Field<string>("Location") == cboLocation.SelectedItem.ToString()
                                      && agent.Field<string>("RealEstateType") == cboRealEstate.SelectedItem.ToString()
                                      select agent;
                if (agentByLocType.Count<DataRow>() != 0)
                {
                    gridAgents.DataSource = agentByLocType.CopyToDataTable(); ;
                }
                else
                {
                    gridAgents.DataSource = null;
                    string message = "At this moment Agent with selected parameters is not available.\nTry to change yor request.";
                    string title = "Thank you for your request!";
                    DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a Language of Employee");
            }
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function Find Agent By Type
        ///|////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void findAgentByRealEstate()
        {
            if (cboRealEstate.SelectedItem != null)
            {
                var agentByType = (from agent in tabAgents.AsEnumerable()
                                       where agent.Field<string>("RealEstateType") == cboRealEstate.SelectedItem.ToString()
                                       select agent).CopyToDataTable();
                gridAgents.DataSource = agentByType;
            }
            else
            {
                MessageBox.Show("Please select a Real Estate Type");
            }
        }


        private void cboLocation_DropDown(object sender, EventArgs e)
        {
            if (cboLocation.Text == "Any Location")
            {
                cboLocation.Text = "";
                cboLocation.ForeColor = Color.Black;
            }
        }

        private void cboLanguage_DropDown(object sender, EventArgs e)
        {
            if (cboLanguage.Text == "Any Language")
            {
                cboLanguage.Text = "";
                cboLanguage.ForeColor = Color.Black;
            }
        }

        private void cboRealEstate_DropDown(object sender, EventArgs e)
        {
            if (cboRealEstate.Text == "Any Real Estate Type")
            {
                cboRealEstate.Text = "";
                cboRealEstate.ForeColor = Color.Black;
            }
        }

        private void lstAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   string selectedName = lstAgents.Text.ToString();
            //var myAgents = (from agent in tabAgents.AsEnumerable()
            //                where agent.Field<string>("FullName") == lstAgents.Text.ToString()
            //                select agent).CopyToDataTable();

            //var AgentToFind = from ag in tabAgents.AsEnumerable()
            //                  where ag.Field<string>("FullName") == lstAgents.Text.ToString()
            //                  select ag;

            //var refAgent = AgentToFind.First()["AgentId"];

            //var HouseToFind = from house in tabHouses.AsEnumerable()
            //                  where house.Field<Int32>("RefAgentId") == Convert.ToInt32(refAgent)
            //                  select new { Type = house.Field<string>("HouseType"), Location = house.Field<string>("Location"), Price = house.Field<decimal>("Price") };

            //if (HouseToFind.Any())
            //{
            //    gridHouses.DataSource = HouseToFind.ToList();
            //}
            //else
            //{
            //    gridHouses.DataSource = null;
            //}

            //gridAgents.DataSource = AgentToFind.CopyToDataTable();
        }
    }
}
