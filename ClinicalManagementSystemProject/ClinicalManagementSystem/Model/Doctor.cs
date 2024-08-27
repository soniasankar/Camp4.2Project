using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagementSystem.Model
{
    //fields
    public class Doctor
    {
        public int DoctorID { get; set; }
        public int UserId { get; set; } // Assuming this is the foreign key referencing the UserId in USERSTABLE
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public string ConsultingFees { get; set; }
        public string Availability { get; set; }

        //constructor
        public Doctor( int userId, string doctorName, string specialization, string consultingFees, string availability)
        {
           
            UserId = userId;
            DoctorName = doctorName;
            Specialization = specialization;
            ConsultingFees = consultingFees;
            Availability = availability;
        }
    }
}
