using ERPApplication.DomainLayer.Models;
using ERPApplication.DomainLayer.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Organisation
{
    public class Employee: BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string Password { get; private set; }
        public DateTime DateRegistered { get; private set; }
        public string JobTitle { get; private set; }
        public int? ReportingManagerId {  get;  private set; }
        public int? UnitId { get; private set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public int EmployeeStatusId { get; private set; }
        public List<Role> Roles { get;  set; }
        public Employee(int id, string firstName, string lastName, string emailAddress, string password, int? unitId, int employeeStatusId, string jobTitle,int? reportingManagerId=null) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            JobTitle = jobTitle;
            Password = password;
            UnitId = unitId;
            ReportingManagerId = reportingManagerId;
            EmployeeStatusId = employeeStatusId;
        }

        public void RegisterNewEmployee(string emailAddress)
        {
            DateRegistered = DateTime.Now;
            Password = GenerateRandomPassword();
            EmailAddress = emailAddress;
        }

        private string GenerateRandomPassword()
        {
            Random rand = new Random();
            var charArr = new string("qwertyuiopasdfghjklzxcvbnm1234567890").ToCharArray();
            string password = string.Empty;
            for(int i=0; i < 20;i++)
            {
                password += charArr[rand.Next(0, charArr.Length)];
            }
            return password;
        }





    }
}
