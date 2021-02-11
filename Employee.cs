using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinRemaxTaianaAntokhine
{
  public class Employee
    {
        private string companyName;
        private string firstName;
        private string lastName;
        private string jobTitle;
        private decimal hourlySalary;
        private DateTime hireDate;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        public decimal HourlySalary { get => hourlySalary; set => hourlySalary = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public DateTime HireDate { get => hireDate; set => hireDate = value; }

        public Employee()
        {
            this.firstName = this.lastName = this.jobTitle = this.companyName =  "undefined";
            this.hourlySalary = 0;
        }

        public Employee(string companyName, string firstName, string lastName, string jobTitle, decimal hourlySalary, DateTime hireDate)
        {
            this.companyName = companyName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.jobTitle = jobTitle;
            this.hourlySalary = hourlySalary;
            this.hireDate = hireDate;
        }

        public override string ToString()
        {
            string info = "\nCompany: " + this.companyName + 
                           "\nFirst Name: " + this.firstName +
                          "\nLast Name: " + this.lastName +
                          "\nJob Title: " + this.jobTitle +
                          "\nHourly Salary: " + this.hourlySalary + 
                          "\nHire Date: " + this.hireDate + "\n";
            return info;
        }
    }


}
