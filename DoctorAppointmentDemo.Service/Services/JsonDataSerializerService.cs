﻿using DoctorAppointmentDemo.Data.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Service.Services
{
    public class JsonDataSerializerService : ISerializationService
    {
        public void Serialize<T>(string path, T data)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        public T Deserialize<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
