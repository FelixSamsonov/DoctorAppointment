using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces;

public interface IPatientRepository : IGenericRepository<Patient>
{
}
