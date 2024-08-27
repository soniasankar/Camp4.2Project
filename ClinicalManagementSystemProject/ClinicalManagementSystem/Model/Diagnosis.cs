using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagementSystem.Model
{
    public class Diagnosis
    {
        //fields
        public int DiagnosisID { get; set; }
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string Symptoms { get; set; }
        public string DiagnosisDetails { get; set; }
        public string MedicineName { get; set; }
        public string TestName { get; set; }
        public string Dosage {  get; set; }
        public string Course { get; set; }


        //constructor
        public Diagnosis(int appointmentId, string patientName, int doctorId,  string symptoms, string diagnosisDetails, string medicineName,string dosage,string course, string testName)
        {
            
            AppointmentId = appointmentId;
            PatientName = patientName; 
            DoctorId = doctorId;                 
            Symptoms = symptoms;
            DiagnosisDetails = diagnosisDetails;
            MedicineName = medicineName;
            TestName = testName;
            Dosage = dosage;
            Course = course;
            
        }
    }
}
