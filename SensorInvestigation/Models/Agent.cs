using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorInvestigation.models;


namespace SensorInvestigation.models
    {
    internal class Agent
        {
        public int ID { get; private set; }

        public string Name { get; set; }
        private string _rank { get; set; }
        private List<string> weakPoints = new();
        public List<string> SensorList = new();
        public string Rank { 
            get {return _rank;}  
            set {
                string[] options = { "private", "sergeant", "lieutenant", "colonel", "general" };
                if (options.Contains(value))
                    {
                    _rank = value;
                    }
                else
                    {
                    Console.WriteLine("Rank Type Not allowed.");
                    }
                } 
            }
        public Agent(string name,string rank, List<string> weaknesses, int id=0)
            {
            ID = id;
            Name = name;
            Rank = rank;
            weakPoints = weaknesses;
            }
        public bool Activate()
            {
            List<string> weaknesses = new(weakPoints);
            List<string> sensors = new(SensorList);
            ActivateSensors();
            int count = CheckAgentWeaknesses(weaknesses, sensors);
            DeActivateSensors();
            Console.WriteLine($"{count}/{weakPoints.Count()}");
            return  (count - weakPoints.Count()) == 0;
            }

        //Recursion sensor scan
        private int CheckAgentWeaknesses(List<string> weaknesses, List<string> sensors, int count=0)
            {
            if (sensors == null || sensors.Count == 0)
                {
                return count;
                }
            else
                {
                if (weaknesses.Contains(sensors[0]))
                    {
                    weaknesses.Remove(sensors[0]);
                    count++;
                    }
                sensors.RemoveAt(0);
                }
            return CheckAgentWeaknesses(weaknesses, sensors, count);
            }

        private void ActivateSensors()
            {
            foreach(string sensor in SensorList)
                {
                //sensor.Activate();
                }
            }

        private void DeActivateSensors()
            {
            foreach (string sensor in SensorList)
                {
                //sensor.InActivate();
                }
            }

        public void Printer()
            {
            Console.WriteLine(

                "\n-----------------------------\n"+
                $"({ID}) {Rank.ToUpper()} \n" +
                $"\t{Name}\n" +
                $"\tWeaknesses: {string.Join(" ",weakPoints)}\n" +
                $"\tSensors: {string.Join(" ", SensorList)}"+
                "\n-----------------------------\n"
                );
            }
        }
    }
