using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicalManagementSystem.Model;

namespace ClinicalManagementSystem.Service
{
    public interface IDoctorService
    {
        //Abstract Methods
        void ListAppointmentService();
        void DiagnosisServive(Diagnosis diagnosis);
        void ListMedicine();
        void ListTest();
        int Doctorname(int appointmentid);
        string Patientservice(int appointmentid);
        void PatientSearchHistory(string PatientName);
    }
}
