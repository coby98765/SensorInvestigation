using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorInvestigation.models;


namespace SensorInvestigation.models
    {
    internal class Test
        {
        public Test(PlayerService playerS)
            {
            PlayerService playerService = playerS;

            Player player = new("coby98760", "1234", "Yaakov", "Moncharsh");
            player = playerService.CreatePlayer(player);
            player.Print();
            
            Factory factory = new();
            Agent agent = factory.CreateAgent();
            List<Sensor> sensors = factory.CreateSensors(2);
            agent.SensorList = sensors;
            agent.Printer();

            Console.WriteLine(agent.Activate());
            }


        }
    }
