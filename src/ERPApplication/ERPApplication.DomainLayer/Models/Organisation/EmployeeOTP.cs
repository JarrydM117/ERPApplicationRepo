using ERPApplication.DomainLayer.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Organisation
{
    public class EmployeeOTP :BaseEntity 
    {
        public int EmployeeId { get; private set; }
        public string OTP {  get; private set; }
        public DateTime DateLogged { get; private set; }
        public Employee Employee { get;  set; }

        public EmployeeOTP(int id,int employeeId, string otp, DateTime datelogged) : base(id)
        {
            EmployeeId = employeeId;
            OTP = otp;
            DateLogged = datelogged;
        }

        public EmployeeOTP(int id , int employeeId):base(id)
        {
            EmployeeId = employeeId;
        }


        public void CreateOTP()
        {
            DateLogged = DateTime.Now;
            GenerateOTP();
        }

        private void GenerateOTP()
        {
            Random rand = new Random();
            OTP = "";
            for (int i = 0; i < 5; i++)
            {
                OTP += rand.Next(10).ToString();
            }

           // OTP = HashValue(OTP);
        }

        public void HashOTP()
        {
            OTP = HashValue(OTP);
        }
        public bool ValidateOTP(string otp)
        {
            return (HashValue(otp) == OTP) && DateLogged.AddMinutes(15) >= DateTime.Now;
        }


        private string HashValue(string value)
        {
            string hashedVal = "";
            using (SHA512 sha = SHA512.Create())
            {
                hashedVal = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(OTP)));
            }
            return hashedVal;
        }
    }
}
