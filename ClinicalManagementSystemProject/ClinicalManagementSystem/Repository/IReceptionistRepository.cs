using ClinicalManagementSystem.Model;

namespace ClinicalManagementSystem.Repository
{
    public interface IReceptionistRepository
    {
       //Abstract methods
        void AddpatientsRepository(Patient patient);
        void Editpatients(string phonenumber);
      
        void SearchAndEditPatient(string phoneNumber);
        void ListDoctor();
        void AppointmentRepository(Appointment appointment,int registration);
        int GenerateBill(int doctorid,int patientId);
        string Billrepository(int doctorid);

      
        int GetPatientIdByName(string patientName);




    }
}