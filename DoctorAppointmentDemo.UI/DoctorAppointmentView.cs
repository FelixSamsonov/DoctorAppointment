using DoctorAppointmentDemo.Domain.Enums;
using DoctorAppointmentDemo.Service.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.UI;

class DoctorAppointmentView
{
    private readonly IDoctorService _doctorService;
    private readonly IPatientService _patientService;
    private readonly IAppointmentService _appointmentService;

    public DoctorAppointmentView()
    {
        _doctorService = new DoctorService();
        _patientService = new PatientService();
        _appointmentService = new AppointmentService();
    }

    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("1 - Make an Appointment");
            Console.WriteLine("2 - Add a Doctor");
            Console.WriteLine("3 - Show All Doctors");
            Console.WriteLine("4 - Show All Patients");
            Console.WriteLine("5 - Show All Appointments");
            Console.WriteLine("6 - Exit");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            if (!Enum.TryParse(input, out MenuOptions choice))
            {
                Console.WriteLine("Invalid choice, try again.");
                continue;
            }

            OptionChoice(choice);
        }
    }

    private void OptionChoice(MenuOptions choice)
    {
        switch (choice)
        {
            case MenuOptions.MakeAnAppointment:
                var appointment = new Appointment();
                Console.WriteLine("Enter the appointment's details: ");
                Console.Write("Patient: ");
                appointment.Patient = new Patient();
                Console.WriteLine("Enter the petient's details: ");
                Console.Write("Patient name: ");
                appointment.Patient.Name = Console.ReadLine();

                Console.Write("Patient surname: ");
                appointment.Patient.Surname = Console.ReadLine();

                Console.Write("Patient addres: ");
                appointment.Patient.Address = Console.ReadLine();

                Console.Write("Patient phone: ");
                appointment.Patient.Phone = Console.ReadLine();

                Console.Write("Patient email: ");
                appointment.Patient.Email = Console.ReadLine();

                Console.WriteLine("IllnessType: ");
                Console.WriteLine("1 - EyeDisease");
                Console.WriteLine("2 - Infection");
                Console.WriteLine("3 - DentalDisease");
                Console.WriteLine("4 - SkinDisease");
                Console.WriteLine("5 - Ambulance");
                while (true)
                {
                    string inputPatientIllnes = Console.ReadLine();
                    if (!Enum.TryParse(inputPatientIllnes, out IllnessTypes patientIllness))
                    {
                        Console.WriteLine("Invalid choice, try again.");
                        continue;
                    }
                    appointment.Patient.IllnessType = patientIllness;
                    break;
                }
                _patientService.Create(appointment.Patient);
                while (true)
                {
                    var doctors = _doctorService.GetAll();
                    Console.WriteLine("Available doctors:");
                    foreach (var doc in doctors)
                        Console.WriteLine($"Doctor's ID - {doc.Id}, {doc.Name} {doc.Surname} - {doc.DoctorType}");
                    Console.Write("Enter doctor's ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int doctorId))
                    {
                        Console.WriteLine("Invalid doctor ID.");
                        continue;
                    }

                    var selectedDoctor = doctors.FirstOrDefault(d => d.Id == doctorId);
                    if (selectedDoctor == null)
                    {
                        Console.WriteLine("Doctor not found.");
                        continue;
                    }
                    appointment.Doctor = selectedDoctor;
                    break;
                }
                while (true)
                {
                    Console.Write("Enter appointment start date and time (dd-MM-yyyy HH:mm): ");
                    if (!DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy HH:mm",
                                                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDateTime))
                    {
                        Console.WriteLine("Invalid date format. Please use dd-MM-yyyy HH:mm.");
                        continue;
                    }
                
                    Console.Write("Enter appointment end date and time (dd-MM-yyyy HH:mm): ");
                    if (!DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy HH:mm",
                                                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDateTime))
                    {
                        Console.WriteLine("Invalid date format. Please use dd-MM-yyyy HH:mm.");
                        continue;
                    }

                    if (endDateTime <= startDateTime)
                    {
                        Console.WriteLine("End time must be after start time.");
                        continue;
                    }

                    appointment.DateTimeFrom = startDateTime;
                    appointment.DateTimeTo = endDateTime;
                    break;
                }
                _appointmentService.Create(appointment);
                Console.WriteLine("New appointment created.");
                break;


            case MenuOptions.AddDoctor:
                var doctor = new Doctor();
                Console.WriteLine("Enter the doctor's details: ");
                Console.Write("Doctor name: ");
                doctor.Name = Console.ReadLine();

                Console.Write("Doctor surname: ");
                doctor.Surname = Console.ReadLine();

                while (true)
                {
                    Console.Write("Doctor experience: ");
                    if (byte.TryParse(Console.ReadLine(), out byte experience))
                        doctor.Experience = experience;
                    else
                        Console.WriteLine("Invalid input");

                    Console.Write("Doctor salary: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal salary))
                        doctor.Salary = salary;
                    else
                        Console.WriteLine("Invalid input");
                    break ;
                }
                Console.Write("Doctor phone: ");
                doctor.Phone = Console.ReadLine();

                Console.Write("Doctor email: ");
                doctor.Email = Console.ReadLine();

                Console.WriteLine("DoctorTypes: ");
                Console.WriteLine("1 - Dentist");
                Console.WriteLine("2 - Dermatologist");
                Console.WriteLine("3 - FamilyDoctor");
                Console.WriteLine("4 - Paramedic");
                string inputDoctorTypes = Console.ReadLine();
                if (!Enum.TryParse(inputDoctorTypes, out DoctorTypes doctorType))
                {
                    Console.WriteLine("Invalid choice, try again.");
                    break;
                }
                doctor.DoctorType = doctorType;
                _doctorService.Create(doctor);
                Console.WriteLine("New doctor created succsesfuly.");
                Console.WriteLine($"Doctor: {doctor.Name}, {doctor.Surname};\n Experience: {doctor.Experience};\n Salary: {doctor.Salary};\n" +
                    $" Phone: {doctor.Phone};\n" + $"Email: {doctor.Email};\n  Type: {doctor.DoctorType}");
                break;



            case MenuOptions.ShowAllDoctors:
                Console.WriteLine("Current doctors list: ");
                var docs = _doctorService.GetAll();
                if (docs != null)
                {
                    foreach (var doc in docs)
                    {
                        Console.WriteLine($"{doc.Surname} - {doc.DoctorType}");
                    }
                }
                break;

            case MenuOptions.ShowAllPatients:
                Console.WriteLine("Current patients list: ");
                var patients = _patientService.GetAll();
                if (patients != null)
                {
                    foreach (var pat in patients)
                    {
                        Console.WriteLine($"{pat.Surname} - {pat.IllnessType}");
                    }
                }
                break;

            case MenuOptions.ShowAllAppointments:
                Console.WriteLine("Current appointment list: ");
                var appointments = _appointmentService.GetAll();
                if (appointments != null)
                {
                    foreach (var app in appointments)
                    {
                        Console.WriteLine($"Patient: {app.Patient.Name} {app.Patient.Surname}, Doctor: {app.Doctor.Name} {app.Doctor.Surname}, " +
                            $"Time: {app.DateTimeFrom} - {app.DateTimeTo}");
                    }
                }
                break;

            case MenuOptions.Exit:
                Console.WriteLine("Exiting...");
                Environment.Exit(0);
                break;
            default: Console.WriteLine("Try choose corect options");
                break;
        }
    }
}

