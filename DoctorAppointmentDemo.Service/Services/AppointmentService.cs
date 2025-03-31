using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Service.Interfaces;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Service.ViewModels;
using DoctorAppointmentDemo.Service.Extensions;

namespace MyDoctorAppointment.Service.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(string appSetting, ISerializationService serializationService)
    {
        _appointmentRepository = new AppointmentRepository(appSetting, serializationService);
    }

    public Appointment Create(Appointment appointment)
    {
        return _appointmentRepository.Create(appointment);
    }

    public bool Delete(int id)
    {
        return _appointmentRepository.Delete(id);
    }

    public Appointment? Get(int id)
    {
        return _appointmentRepository.GetById(id);
    }

    public List<AppointmentViewModel> GetAll()
    {
        var appointment = _appointmentRepository.GetAll();
        if (appointment == null || appointment.Count == 0)
        {
            return new List<AppointmentViewModel>();
        }

        var appointmentViewModel = appointment.Select(x => x.ConvertTo()).ToList();
        return appointmentViewModel;
    }

    public Appointment Update(int id, Appointment appointment)
    {
        return _appointmentRepository.Update(id, appointment);
    }
}
