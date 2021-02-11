using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinRemaxTaianaAntokhine
{
   public class clsBuyer: clsClient
    {
        private string type; //investor, retail, luxury;

        public clsBuyer(): base()
        {
            this.type = "undefined";
        }

        public clsBuyer(int clientId, string firstName, string lastName, string phone, string email, string address, string status, int refAgentId, string type) : base(clientId, firstName, lastName, phone, email, address, status, refAgentId)
        {
            this.type = type;
        }

        public void RegisterBuyer(int clientId, string firstName, string lastName, string phone, string email, string address, string type)
        {
            ClientId = clientId;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Address = address;
            Status = "active";
            this.type = type;
        }
        public override string ToString()
        {
            return base.ToString() +
                "\nBuyer Type: " + this.type + "\n";
        }













    }


}
