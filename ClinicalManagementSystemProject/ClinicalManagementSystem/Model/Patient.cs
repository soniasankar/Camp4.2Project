using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagementSystem.Model
{
    public class Patient
    {
        //properties
        private int Patientid {  get; set; }
        public string PatientName { get; set; }
        public string DOB {  get; set; }
        public string Address { get; set; }
        public string Bloodgroup {  get; set; }
        public string Gender {  get; set; }
        public string Email {  get; set; }
        public string Phonenumber {  get; set; }
        

        public Patient()
        {


        }
        //constructor
        public Patient( string patientName, string dOB, string address, string bloodgroup, string gender, string email, string phonenumber)
        {
            
            PatientName = patientName;
            DOB = dOB;
            Address = address;
            Bloodgroup = bloodgroup;
            Gender = gender;
            Email = email;
            Phonenumber = phonenumber;
            
        }
    }
}
 