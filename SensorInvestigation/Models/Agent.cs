using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public Agent(string name,string rank,string weaknesses)
            {
            Name = name;
            Rank = rank;
            weakPoints = weaknesses.Split(" ").ToList();
            }
        public int Activate()
            {
            return 0;
            }
        }
    }
