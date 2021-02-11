using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinRemaxTaianaAntokhine
{
   public class clsClient
    {
        private int clientId;
        private string firstName;
        private string lastName;
        private string phone;
        private string email;
        private string address;
        private string status;
        private clsListHouses house;
        private int refAgentId; // - referense to Agent

       

        public int ClientId { get => clientId; set => clientId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string Status { get => status; set => status = value; }
        public clsListHouses House { get => house; set => house = value; }
        public int RefAgentId { get => refAgentId; set => refAgentId = value; }

        public clsClient()
        {
            this.clientId = this.refAgentId = 0;
            this.firstName = this.lastName = this.phone = this.email = this.address = this.status = "undefined";
            this.house = new clsListHouses();
        }

        public clsClient(int clientId, string firstName, string lastName, string phone, string email, string address, string status, clsListHouses house, int refAgentId)
        {
            this.clientId = clientId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.status = status;
            this.house = house;
            this.refAgentId = refAgentId;
        }

        public clsClient(int clientId, string firstName, string lastName, string phone, string email, string address, string status, int refAgentId)
        {
            this.clientId = clientId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.status = status;
            this.refAgentId = refAgentId;
            this.house = new clsListHouses();
        }

        public void RegisterClient(int clientId, string firstName, string lastName, string phone, string email, string address, int refAgentId)
        {
            this.clientId = clientId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.refAgentId = refAgentId;
            this.status = "active";
        }

        public string DisplayClient()
        {
                            
            string info = "\nClient Number: " + this.ClientId +
                          "\nFirst Name: " + this.FirstName +
                          "\nLast Name: : " + this.LastName +
                          "\nPhone Number: " + this.Phone +
                          "\nEmail: " + this.Email +
                          "\nAddress: " + this.Address +
                          "\nStatus: " + this.Status + 
                          "\nAgent Number: " + this.RefAgentId + 
                          "\nHouses: " + house.Display() + "\n";
            return info;
        }















    }

 
}
