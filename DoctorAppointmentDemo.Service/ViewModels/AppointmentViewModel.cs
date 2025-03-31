using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorAppointmentDemo.Service.ViewModels
{
    public class AppointmentViewModel
    {
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public DateTime DateTimeFrom { get; set; }

        public DateTime DateTimeTo { get; set; }
        public string? Description { get; set; }
    

    public class AppointmentList
    {
        [XmlElement("Appointment")]
        public List<AppointmentViewModel> Apointments { get; set; }
    }
}
}
