using SensorInvestigation.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorInvestigation.models
    {
    internal class Controllers
        {
        private PlayerControllers playerControllers;
        public Controllers(PlayerService playerS)
            {
            playerControllers = new(playerS);

            }

        public Player MainLogin()
            {
            Console.WriteLine("To Enter The Investigation Room you need to Log-in.");
            string username = PlayerControllers.LoginEntery("Username");
            string password = PlayerControllers.LoginEntery("Password");

            Player player = playerControllers.LogIn(username, password);

            return player;
            }
        }
    }
