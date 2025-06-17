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
        private readonly string[] typeOfSensors = { "basic", "audio", "thermal" };
        private readonly string[] typeOfSensRank = { "private", "sergeant", "lieutenant", "colonel", "general" };

        private Random rnd = new();
        public Agent CreateAgent(string name)
            {
            int RankIndex = rnd.Next(typeOfSensRank.Length);
            string rank = typeOfSensRank[RankIndex];
            List<string> weaknesses = CreateWeaknesses(RankIndex + 1);
            Agent agent = new(name, rank, weaknesses);
            return agent;
            }

        private List<string> CreateWeaknesses(int amount)
            {
            List<string> weaknesses = new();
            for(int i = 0;amount * 2 >= i; i++)
                {
                int index = rnd.Next(typeOfSensors.Length);
                weaknesses.Add(typeOfSensors[index]);
                }
            return weaknesses;
            }
        }
    }
