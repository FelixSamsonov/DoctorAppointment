using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;


namespace DoctorAppointmentDemo.Data.Repositories;

public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
{

    private readonly ISerializationService serializationService;
    public override string Path { get; set; }

    public override int LastId { get; set; }

    public AppointmentRepository(string appSetting, ISerializationService serializationService) : base(appSetting, serializationService)
    {
        this.serializationService = serializationService;

        var result = ReadFromAppSettings();

        Path = result.Database.Appointments.Path;
        LastId = result.Database.Appointments.LastId;
    }


    public override void ShowInfo(Appointment appointment)
    {
    }

    protected override void SaveLastId()
    {
        var result = ReadFromAppSettings();
        result.Database.Appointments.LastId = LastId;
        serializationService.Serialize(AppSettings, result);
    }
}


