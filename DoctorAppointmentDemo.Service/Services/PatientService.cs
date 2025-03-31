using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Service.Extensions;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.ViewModels;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using System.ComponentModel.Design;

namespace MyDoctorAppointment.Service.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(string appSetting, ISerializationService serializationService)
    {
        _patientRepository = new PatientRepository(appSetting, serializationService);
    }

    public Patient Create(Patient patient)
    {
        return _patientRepository.Create(patient);
    }

    public bool Delete(int id)
    {
        return _patientRepository.Delete(id);
    }

    public Patient? Get(int id)
    {
        return _patientRepository.GetById(id);
    }

    public List <PatientViewModel> GetAll()
    {
        var patient = _patientRepository.GetAll();
        if (patient == null || patient.Count == 0) 
        {
            return new List<PatientViewModel>(); 
        }

        var patientViewModel = patient.Select(x => x.ConvertTo()).ToList();
        return patientViewModel;  
    }

    public Patient Update(int id, Patient patient)
    {
        return _patientRepository.Update(id, patient);
    }
}
