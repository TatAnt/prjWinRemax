using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace prjWinRemaxTaianaAntokhine
{
   public static class clsGlobalVaiables
    {
        public static DataSet mySet;
        public static SqlDataAdapter adpEmployees, adpAdmins, adpCompany, adpHouses, adpHouseType, adpClients, adpUsers;
    }
}
