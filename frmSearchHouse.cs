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
    public partial class frmSearchHouse : Form
    {
        public frmSearchHouse()
        {
            InitializeComponent();
        }
        DataTable tabHouses, tabhouseType;
        SqlCommand myCmd;
        private void frmSearchHouse_Load(object sender, EventArgs e)
        {
            txtHouseId.Text = "Enter House ID";
            tabHouses = clsGlobalVaiables.mySet.Tables["Houses"];
            tabhouseType = clsGlobalVaiables.mySet.Tables["HouseTypes"];
            //Fill listBox with types of Houses
            var houseType = from house in tabhouseType.AsEnumerable()
                            select new { HouseType = house.Field<string>("HouseType") };
            lstHouseType.DisplayMember = "HouseType";
            lstHouseType.DataSource = houseType.ToList();

        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|BUTTON Find ALL Houses
        ///|////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnSearchAllHouses_Click(object sender, EventArgs e)
        {
            searchAllHouses();
            DataTable tabHouses = new DataTable(); //clear gridView to avoid duplicating data from DataSet
        }


        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function Find ALL Houses
        ///|////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void searchAllHouses()
        {
            var allHouses = (from house in tabHouses.AsEnumerable()
                             select house).CopyToDataTable();
            gridHouses.DataSource = allHouses;
           
        }

        ///|/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///|Function Find House By ID
        ///|////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnSearchHouseById_Click(object sender, EventArgs e)
        {
            if (txtHouseId.Text != null || txtHouseId.Text != "Enter House ID")
            {
                findHousetByID();
            }

        }



        private void findHousetByID()
        {
            int a;
            //int houseId = Convert.ToInt32(txtHouseId.Text);
            gridHouses.DataSource = null;

            //=============Check if Row exists in DataTable tabHouses======================================================
            var idExists = from house in tabHouses.AsEnumerable()
                           where house.Field<int>("HouseId") == Convert.ToInt32(txtHouseId.Text)
                           select house.Field<int>("HouseId");

            //if (!int.TryParse(txtHouseId.Text, out a))
            //{
            //    MessageBox.Show("Please enter valid House ID!");
            //    return;
            //}else
            if (idExists.Any())
            {
                var housesById = (from house in tabHouses.AsEnumerable()
                                  where house.Field<int>("HouseId") == Convert.ToInt32(txtHouseId.Text)
                                  select house).CopyToDataTable();
                gridHouses.DataSource = housesById;
                txtHouseId.Text = "Enter House ID";
            }
            else
            {
                int houseId = Convert.ToInt32(txtHouseId.Text);
                MessageBox.Show("House with ID " + houseId + " was not found!");
            }
        }

            private void txtHouseId_Enter(object sender, EventArgs e)
        {
            if (txtHouseId.Text == "Enter House ID")
            {
                txtHouseId.Text = "";
                txtHouseId.ForeColor = Color.Black;
            }
        }

        private void txtHouseId_Leave(object sender, EventArgs e)
        {
            if (txtHouseId.Text.Trim() == "")
            {
                txtHouseId.Text = "Enter House ID";
            }
        }

        private void lstHouseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = lstHouseType.Text.ToString();
            var HouseToFind = from house in tabHouses.AsEnumerable()
                              where house.Field<string>("HouseType") == selectedType
                              select house;
            gridHouses.DataSource = HouseToFind.CopyToDataTable();
        }
    }
}
