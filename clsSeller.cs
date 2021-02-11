using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinRemaxTaianaAntokhine
{
    public class clsSeller: clsClient
    {
        private int numberOfHouses;
        public clsSeller(): base()
        {
            this.numberOfHouses = 0;
        }

        public clsSeller(int clientId, string firstName, string lastName, string phone, string email, string address, string status, clsListHouses house, int refAgentId, int numberOfHouses) : base(clientId, firstName, lastName, phone, email, address, status, house, refAgentId)
        {
            this.numberOfHouses = numberOfHouses;
        }

        public void RegisterSeller(int clientId, string firstName, string lastName, string phone, string email, string address, int numberOfHouses)
        {
            ClientId = clientId;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Address = address;
            Status = "active";
            this.numberOfHouses = numberOfHouses;
        }
        public override string ToString()
        {
            return base.ToString() +
                "\nBuyer Type: " + this.numberOfHouses + "\n";
        }














    }
}
