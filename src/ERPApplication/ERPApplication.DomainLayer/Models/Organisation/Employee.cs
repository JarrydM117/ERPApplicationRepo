using ERPApplication.DomainLayer.Models;
using ERPApplication.DomainLayer.Models.Tickets;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

        public bool VerifyCredentials(string password)
        {
            PasswordHasher pw = new PasswordHasher();
            return pw.VerifyHashedPassword(Password, password) == PasswordVerificationResult.Success;
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
            PasswordHasher pw = new PasswordHasher();
            password = pw.HashPassword(password);
            return password;
        }


        public void UpdateDetails(string firstName, string lastName, string jobTitle,int unitId,int reportingManager)
        {
            if (ValidateEmployeeStatus())
                throw new InvalidOperationException("Employee account is no longer active.");
            FirstName = firstName;
            LastName = lastName;
            JobTitle = jobTitle;
            UnitId = unitId;
            ReportingManagerId = reportingManager;
        }

        public void UpdateEmployeeStatus(int statusId)
        {
            EmployeeStatusId = statusId;
        }
        public bool ValidateEmployeeStatus()
        {
            return EmployeeStatusId == 3;
        }

    }
}
