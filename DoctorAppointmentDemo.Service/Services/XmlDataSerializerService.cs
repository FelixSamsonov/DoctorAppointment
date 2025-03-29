using DoctorAppointmentDemo.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorAppointmentDemo.Service.Services
{
    public class XmlDataSerializerService : ISerializationService
    {
        public T Deserialize<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        public void Serialize<T>(string path, T data)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
            }
        }
    }
}
