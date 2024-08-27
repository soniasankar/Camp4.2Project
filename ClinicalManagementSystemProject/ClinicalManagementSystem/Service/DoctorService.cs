using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ClinicalManagementSystem.Model;
using ClinicalManagementSystem.Repository;

namespace ClinicalManagementSystem.Service
{
    public class DoctorService : IDoctorService
    {
        //constructor injection
        private readonly IDoctorRepository doctorRepository;
        public DoctorService(IDoctorRepository _doctorRepository)
        {
            doctorRepository = _doctorRepository;
        }
        public void ListAppointmentService()
        {
            doctorRepository.ListAppointment();
        }
        public void DiagnosisServive(Diagnosis diagnosis)
        {
            doctorRepository.AddDiagnosisRepository(diagnosis);
        }
      
        public void ListMedicine()
        {
            doctorRepository.MedicineList();
        }
        public void ListTest()
        {
            doctorRepository.TestList();
        }
        public int Doctorname(int appointmentid)
        {
            return doctorRepository.Doctorname(appointmentid);
            
        }
        public string Patientservice(int appointmentid)
        {
            return doctorRepository.PatientRepository(appointmentid);
        }
        public void PatientSearchHistory(string PatientName)
        {
             doctorRepository.SearchPatientHistory(PatientName);
        }
    }
}
