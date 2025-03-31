using DoctorAppointmentDemo.Service.ViewModels;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Service.Interfaces;

public interface IAppointmentService
{
    Appointment Create(Appointment appointment);

    List<AppointmentViewModel> GetAll();

    Appointment? Get(int id);

    bool Delete(int id);

    Appointment Update(int id, Appointment appointment);
}
