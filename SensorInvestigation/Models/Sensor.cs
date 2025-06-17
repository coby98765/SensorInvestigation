using SensorInvestigation.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorInvestigation.models
    {
    internal class Sensor
        {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Active = false;

        public Sensor(string name, string type, int id=0)
            {
            ID = id;
            Name = name;
            Type = type;
            }
        
        public void Activate()
            {
            Active = true;
            }
        public void InActivate()
            {
            Active = false;
            }
        }
}