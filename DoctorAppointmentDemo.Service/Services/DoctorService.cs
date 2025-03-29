using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Service.Extensions;
using DoctorAppointmentDemo.Service.ViewModels;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment.Service.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(string appSetting, ISerializationService serializationService)
    {
        _doctorRepository = new DoctorRepository(appSetting, serializationService);
    }

    public Doctor Create(Doctor doctor)
    {
        return _doctorRepository.Create(doctor);
    }

    public bool Delete(int id)
    {
        return _doctorRepository.Delete(id);
    }

    public Doctor? Get(int id)
    {
        return _doctorRepository.GetById(id);
    }

    public IEnumerable<DoctorViewModel> GetAll()
    {
        var doctors = _doctorRepository.GetAll();
        var doctorViewModels = doctors.Select(x => x.ConvertTo());
        return doctorViewModels;
    }

    public Doctor Update(int id, Doctor doctor)
    {
        return _doctorRepository.Update(id, doctor);
    }
}
