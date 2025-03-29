using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class Repository
    {
        public Database Database { get; set; }
    }
    public class Database
    {
        public ConfigEntity Appointments { get; set; }
        public ConfigEntity Doctors { get; set; }
        public ConfigEntity Patients { get; set; }  
    }
    public class ConfigEntity
    {
        public int LastId { get; set; }
        public string Path { get; set; }   
    }
}
