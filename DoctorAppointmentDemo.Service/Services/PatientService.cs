﻿//using DoctorAppointmentDemo.Data.Repositories;
//using DoctorAppointmentDemo.Service.Interfaces;
//using MyDoctorAppointment.Data.Interfaces;
//using MyDoctorAppointment.Data.Repositories;
//using MyDoctorAppointment.Domain.Entities;
//using MyDoctorAppointment.Service.Interfaces;
//using System.ComponentModel.Design;

//namespace MyDoctorAppointment.Service.Services;

//public class PatientService : IPatientService
//{
//    private readonly IPatientRepository _patientRepository;

//    public PatientService(string appSetting, ISelectionService serializationService)
//    {
//        _patientRepository = new PatientRepository(appSetting, serializationService);
//    }

//    public Patient Create(Patient patient)
//    {
//        return _patientRepository.Create(patient);
//    }

//    public bool Delete(int id)
//    {
//        return _patientRepository.Delete(id);
//    }

//    public Patient? Get(int id)
//    {
//        return _patientRepository.GetById(id);
//    }

//    public IEnumerable<Patient> GetAll()
//    {
//        return _patientRepository.GetAll();
//    }

//    public Patient Update(int id, Patient patient) 
//    {
//        return _patientRepository.Update(id, patient);
//    }
//}
