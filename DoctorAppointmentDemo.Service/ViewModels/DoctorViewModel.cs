﻿using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorAppointmentDemo.Service.ViewModels
{

    public class DoctorViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? DoctorType { get; set; }
        public byte Experience { get; set; }
        public decimal Salary { get; set; }
    }

    public class DoctorList
    {
        [XmlElement("Doctor")] 
        public List<DoctorViewModel> Doctors { get; set; }
    }

}

