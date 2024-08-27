using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagementSystem.Model
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public int DoctorID { get; set; }
        public string ReasonForAppointment { get; set; }
        public string AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public int Token { get; set; }
        public Appointment(string patientName, int doctorID, string reasonForAppointment,string appointmentDate, TimeSpan appointmentTime,int token)
        {
            PatientName = patientName;
            DoctorID = doctorID;
            ReasonForAppointment = reasonForAppointment;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            Token = token;
        }
    }

}
