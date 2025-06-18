using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorInvestigation.models;


namespace SensorInvestigation.models
    {
    internal class Factory
        {
        private readonly string[] typeOfSensors = {"audio", "thermal", "pulse", "motion", "magnetic", "signal", "light"};
        private readonly string[] typeOfSensRank = { "private", "sergeant", "lieutenant", "colonel", "general" };
        public List<Sensor> sensors = new();
        private Random rnd = new();
        public Agent CreateAgent()
            {
            string name = CreateName();
            //temp for testing
            int RankIndex = 0;
            //int RankIndex = rnd.Next(typeOfSensRank.Length);
            string rank = typeOfSensRank[RankIndex];
            List<string> weaknesses = CreateWeaknesses(RankIndex + 1);
            Agent agent = new(name, rank, weaknesses);
            return agent;
            }

        public List<Sensor> CreateSensors(int amount)
            {
            List<Sensor> sensors = new();
            for(int i=0; i <=amount;i++)
                {
                int rndType = rnd.Next(typeOfSensors.Count());
                Sensor sensor = new(typeOfSensors[rndType], sensors.Count() + 1);
                sensors.Add(sensor);
                }
            return sensors;
            }


        private List<string> CreateWeaknesses(int amount)
            {
            List<string> weaknesses = new();
            for(int i = 0;amount * 2 > i; i++)
                {
                int index = rnd.Next(typeOfSensors.Length);
                weaknesses.Add(typeOfSensors[index]);
                }
            return weaknesses;
            }

        private string CreateName()
            {
            string[] firstNames = new string[]
                {
                "Ali", "Reza", "Hossein", "Mehdi", "Mohammad",
                "Qassem", "Ebrahim", "Kian", "Amir", "Saeed",
                "Nima", "Farhad", "Yousef", "Omid", "Navid",
                "Sina", "Hamid", "Arash", "Behnam", "Milad", 
                "Fatemeh", "Zahra", "Maryam", "Leila", "Narges",
                "Shirin", "Parvaneh", "Roya", "Yasaman", "Sahar",
                "Mina", "Taraneh", "Sepideh", "Sanaz", "Ladan",
                "Mahsa", "Niloufar", "Arezoo", "Azadeh", "Negar"
                };

            string[] lastNames = new string[]
                {
                "Soleimani", "Khamenei", "Rafsanjani", "Zand",
                "Shirazi", "Khomeini", "Mousavi", "Ahmadinejad", "Rezai", "Tajrishi",
                "Khazeni", "Yazdi", "Tehrani", "Ghaffari", "Sadeghi",
                "Farrokhzad", "Etemad", "Zandjani", "Bakhtiari", "Javadi",
                "Petrosyan", "Arshakian", "Danielyan", "Ghazarian", "Avetisyan",
                "Sarkisyan", "Babayan", "Tadevosyan", "Melikyan", "Harutyunyan",
                "Martirosyan", "Karapetyan", "Vardanyan", "Minasyan", "Gevorgyan",
                "Stepanyan", "Khachaturyan", "Barseghyan", "Manukyan", "Simonyan"
                };

            string name = "";
            name += firstNames[rnd.Next(firstNames.Length)] +" ";
            name += lastNames[rnd.Next(lastNames.Length)];
            return name;
            }
        }
    }
