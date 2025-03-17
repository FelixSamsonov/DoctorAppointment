using DoctorAppointmentDemo.Domain.Enums;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.UI;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using System;
using System.Globalization;

    public static class Program
    {
        public static void Main()
        {
            var doctorAppointmentView = new DoctorAppointmentView();
            doctorAppointmentView.Menu();

        }
    }


