using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicalManagementSystem.Model;

namespace ClinicalManagementSystem.Repository
{
    public interface IDoctorRepository
    {
        //Abstract Methods
        void ListAppointment();
        void AddDiagnosisRepository(Diagnosis diagnosis);
        void MedicineList();
        void TestList();
        int Doctorname(int appointmentid);
        string PatientRepository(int appointmentid);
        void SearchPatientHistory(string PatientName);
    }
}
