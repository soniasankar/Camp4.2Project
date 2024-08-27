using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ClinicalManagementSystem.Model;
using ClinicalManagementSystem.Repository;

namespace ClinicalManagementSystem.Service
{
    public class ReceptionistService : IReceptionistService
    {
  
        private readonly IReceptionistRepository receptionistRepository;
        //constructor object creation 
        public ReceptionistService(IReceptionistRepository _receptionistRepository)
        {
           receptionistRepository = _receptionistRepository;
        }
        public void AddPatientService(Patient patient)
        {
            receptionistRepository.AddpatientsRepository(patient);
        }
        public void EditpatientsService(string phonenumber)
        {

            receptionistRepository.Editpatients(phonenumber);
        }
        //public void ListpatientsService()
        //{
            //receptionistRepository.Listpatients( );
        //}
        public void searchpatientsService(string phoneNumber)
        {
            receptionistRepository.SearchAndEditPatient(phoneNumber);
        }
        public void ListDoctorService()
        {
            receptionistRepository.ListDoctor();
        }
        public void AppointmentService(Appointment appointment,int registration)
        {
            receptionistRepository.AppointmentRepository(appointment,registration);
        }     
        //for applying buisness rule call
        public int GenerateBillservice(int doctorid, int patientId )
        {
            //add validation business logic here
            //add validation with bll
            return receptionistRepository.GenerateBill(doctorid,patientId );
        }
        public string Billservice(int doctorid)
        {
            // Add validation business logic here
            // Add validation with BLL
            return receptionistRepository.Billrepository(doctorid);
        }

        public int GetPatientIdByName(string patientName)
        {
            //
            return receptionistRepository.GetPatientIdByName (patientName); 
        }


    }
}
