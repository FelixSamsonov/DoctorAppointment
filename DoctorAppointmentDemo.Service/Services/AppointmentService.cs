//using DoctorAppointmentDemo.Data.Repositories;
//using DoctorAppointmentDemo.Service.Interfaces;
//using MyDoctorAppointment.Data.Interfaces;
//using MyDoctorAppointment.Data.Repositories;
//using MyDoctorAppointment.Domain.Entities;
//using MyDoctorAppointment.Service.Interfaces;
//using DoctorAppointmentDemo.Data.Interfaces;

//namespace MyDoctorAppointment.Service.Services;

//public class AppointmentService : IAppointmentService
//{
//    private readonly IAppointmentRepository _appointmentRepository;

//    public AppointmentService(string appSetting, ISerializationService serializationService)
//    {
//        _appointmentRepository = new AppointmentRepository(appSetting, serializationService);
//    }

//    public Appointment Create(Appointment appointment)
//    {
//        return _appointmentRepository.Create(appointment);
//    }

//    public bool Delete(int id)
//    {
//        return _appointmentRepository.Delete(id);
//    }

//    public Appointment? Get(int id)
//    {
//        return _appointmentRepository.GetById(id);
//    }

//    public IEnumerable<Appointment> GetAll()
//    {
//        var doctors = _appointmentRepository.GetAll();
//        var doctorViewModels = doctors.Select(x => x.ConvertTo());
//        return doctorViewModels;
//    }

//    public Appointment Update(int id, Appointment appointment)
//    {
//        return _appointmentRepository.Update(id, appointment);
//    }
//}
