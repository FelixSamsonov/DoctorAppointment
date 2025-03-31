using DoctorAppointmentDemo.Service.ViewModels;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Service.Extensions
{
    public static class Mapper
    {
        public static DoctorViewModel ConvertTo(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            string doctorType;

            switch (doctor.DoctorType)
            {
                case DoctorTypes.Dentist:
                    doctorType = "Dentist";
                    break;
                case DoctorTypes.Dermatologist:
                    doctorType = "Dermatologist";
                    break;
                case DoctorTypes.FamilyDoctor:
                    doctorType = "FamilyDoctor";
                    break;
                case DoctorTypes.Paramedic:
                    doctorType = "Paramedic";
                    break;
                default:
                    doctorType = "Unknown";
                    break;
            }

            return new DoctorViewModel()
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Phone = doctor.Phone,
                Email = doctor.Email,
                DoctorType = doctorType,
                Experience = doctor.Experience,
                Salary = doctor.Salary
            };
        }
        public static PatientViewModel ConvertTo(this Patient patient)
        {
            if (patient == null)
                return null;

            string illnessType;

            switch (patient.IllnessType)
            {
                case IllnessTypes.EyeDisease:
                    illnessType = "EyeDisease";
                    break;
                case IllnessTypes.DentalDisease:
                    illnessType = "DentalDisease";
                    break;
                case IllnessTypes.SkinDisease:
                    illnessType = "SkinDisease";
                    break;
                case IllnessTypes.Infection:
                    illnessType = "Infection";
                    break;
                case IllnessTypes.Ambulance:
                    illnessType = "Ambulance";
                    break;
                default:
                    illnessType = "Unknown";
                    break;
            }

            return new PatientViewModel()
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Phone = patient.Phone,
                Email = patient.Email,
                IllnessType = illnessType,
                Address = patient.Address,
            };
        }
        public static AppointmentViewModel ConvertTo(this Appointment appointment)
        {
            if (appointment == null)
                return null;

            return new AppointmentViewModel()
            {
                Patient = appointment.Patient,
                Doctor = appointment.Doctor,
                DateTimeFrom = appointment.DateTimeFrom,
                DateTimeTo = appointment.DateTimeTo,
                Description = appointment.Description,
            };
        }
    }
}

