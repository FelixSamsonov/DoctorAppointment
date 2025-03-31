﻿using DoctorAppointmentDemo.Service.ViewModels;
using MyDoctorAppointment.Domain.Entities;

namespace DoctorAppointmentDemo.Service.Interfaces;

public interface IPatientService
{
    Patient Create(Patient patient);
    List <PatientViewModel> GetAll();
    Patient? Get(int id);
    bool Delete(int id);
    Patient Update(int id, Patient patient); 
}
