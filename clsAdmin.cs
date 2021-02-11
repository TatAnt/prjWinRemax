using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinRemaxTaianaAntokhine
{
   public class clsAdmin : Employee
    {
        private decimal yearlySalary;
        private decimal salaryBonus;
        clsListAgents agent;

        public decimal YearlySalary { get => yearlySalary; set => yearlySalary = value; }
        public decimal SalaryBonus { get => salaryBonus; set => salaryBonus = value; }
        public clsListAgents Agent { get => agent; set => agent = value; }

        public clsAdmin() : base()
        {
            this.yearlySalary = 0;
            this.salaryBonus = 0;
            this.agent = new clsListAgents();
        }

        public clsAdmin(string companyName, string firstName, string lastName, string jobTitle, decimal hourlySalary, DateTime hireDate, decimal yearlySalary, decimal salaryBonus) : base(companyName, firstName, lastName, jobTitle, hourlySalary, hireDate)
        {
            this.yearlySalary = yearlySalary;
            this.salaryBonus = salaryBonus;
            this.agent = new clsListAgents();
        }

        public override string ToString()
        {
            return base.ToString() + "\nYearly Salary: " + this.yearlySalary +
                                    "\nSalary Bonus: " + this.salaryBonus + 
                                    "\nAgents: " + agent.Display() + "\n";
        }
    }
}
