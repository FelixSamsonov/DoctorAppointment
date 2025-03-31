using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Service.ViewModels;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using System.Xml.Serialization;

namespace MyDoctorAppointment.Service.Services
{
    public class XmlDataSerializerService : ISerializationService
    {
        public void Serialize<T>(string path, T data)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
            }
        }
        public T Deserialize<T>(string path)
        {
            XmlSerializer? serializer = new XmlSerializer(typeof(T));

            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

    }
}
