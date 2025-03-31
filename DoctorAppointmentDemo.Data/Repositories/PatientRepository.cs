using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
namespace DoctorAppointmentDemo.Data.Repositories;

public class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    private readonly ISerializationService serializationService;
    public override string Path { get; set; }

    public override int LastId { get; set; }

    public PatientRepository(string appSetting, ISerializationService serializationService) : base(appSetting, serializationService)
    {
        this.serializationService = serializationService;

        var result = ReadFromAppSettings();

        Path = result.Database.Patients.Path;
        LastId = result.Database.Patients.LastId;
    }


    public override void ShowInfo(Patient patient)
    {
    }

    protected override void SaveLastId()
    {
        var result = ReadFromAppSettings();
        result.Database.Patients.LastId = LastId;
        serializationService.Serialize(AppSettings, result);
    }
}



