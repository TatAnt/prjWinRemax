using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinRemaxTaianaAntokhine
{
    public class clsAgent: Employee
    {
        private int agentId;
        private string status;
        private string email;
        private string phone;
        private clsListClients client;


        public int AgentId { get => agentId; set => agentId = value; }
        public string Status { get => status; set => status = value; }
        internal clsListClients Client { get => client; set => client = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }

        public clsAgent() : base()
        {
            this.agentId = 0;
            this.status = this.email = this.phone = "undefined";
            this.client = new clsListClients();
        }

        public clsAgent(string companyName, string firstName, string lastName, string jobTitle,  decimal hourlySalary, DateTime hireDate, int agentId, string status, string email, string phone) : base(companyName, firstName, lastName, jobTitle, hourlySalary, hireDate)
        {
            this.agentId = agentId;
            this.status = status;
            this.email = email;
            this.phone = phone;
            this.client = new clsListClients();
        }


        public void RegisterAgent(int agentId, string firstName, string lastName, string address, string email, string phone)
        {
            AgentId = agentId;
            FirstName = firstName;
            LastName = lastName;
            this.email = email;
            this.phone = phone;
            this.HireDate = DateTime.Today;
            this.status = "active";
        }

        public string DisplayAgent()
        {
            string info = "\nCompany: " + CompanyName +
                          "\nEmployee Number: " + this.agentId +
                          "\nFirst Name: " + FirstName +
                          "\nLast Name: : " + LastName +
                          "\nEmail: " + this.email +
                          "\nPhone Number: " + this.phone +
                          "\nStatus: " + this.status +
                          "\nClients: " + client.Display() + "\n";
            return info;
        }

    }
}

