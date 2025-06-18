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
        public string Type { get; set; }
        public bool Active = false;

        public Sensor(string type, int id=0)
            {
            ID = id;
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