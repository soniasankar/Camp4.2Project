using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicalManagementSystem.Model;

namespace ClinicalManagementSystem.Service
{
    public interface IReceptionistService
    {
        //Abstract Methods
         void AddPatientService(Patient patient);
         void EditpatientsService(string phonenumber);
       
         void searchpatientsService(string phoneNumber);
         void ListDoctorService();
         void AppointmentService(Appointment appointment, int registration);
        int GenerateBillservice(int doctorid, int patientid);
         string Billservice(int doctorid);
        int GetPatientIdByName(string patientName);
    }
}
