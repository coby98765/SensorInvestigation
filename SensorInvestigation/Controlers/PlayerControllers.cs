using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorInvestigation.models
    {
    internal class PlayerControllers
        {
        private PlayerService playerService;
        public PlayerControllers(PlayerService playerS)
            {
            playerService = playerS;
            }

        public Player LogIn(string userName, string password)
            {
            Player player = playerService.GetPlayerByUsername(userName);
            if (player.Login(password))
                {
                return player;
                }
            else { return null; }
            }
        public Player Register()
            {
            Console.WriteLine("Let's create an account.");
            string firstName = nameEntry("first");
            string lastName = nameEntry("last");
            string userName = CreateUsername();
            string password = CreatePassword();
            Console.WriteLine("Enter a Username name: ");
            Console.WriteLine("Enter a Password name: ");
            if (firstName == null || lastName == null || userName == null || password == null) { return null; }
            Player player = new(userName, password, firstName, lastName);
            player = playerService.CreatePlayer(player);
            return player;
            }

        private string nameEntry(string title)
            {
            string entry = "";
            int attempts = 0;
            while (entry == null || entry.Length < 1 || attempts < 4)
                {
                Console.WriteLine($"Enter {title} name: ");
                entry = Console.ReadLine();

                if (entry == null || entry.Length < 1)
                    {
                    Console.WriteLine($"! Error !  {title} name cant be empty.");
                    }
                if (attempts < 4)
                    {
                    Console.WriteLine($"! Error !  Too much attempts.");
                    return null;
                    }
                }
            return entry;
            }
        private string CreateUsername()
            {
            string entry = "";
            int attempts = 0;
            while (entry.Length < 1 || attempts < 4)
                {
                Console.WriteLine($"Enter a Username: ");
                entry = Console.ReadLine();

                if (entry.Length < 1)
                    {
                    Console.WriteLine($"! Error !  Username cant be empty.");
                    }
                if (entry.Length <= 8)
                    {
                    Console.WriteLine($"! Error !  Username too short (at lest 8 chars).");
                    }
                if (attempts < 4)
                    {
                    Console.WriteLine($"! Error !  Too much attempts.");
                    return null;
                    }
                }
            if (playerService.GetPlayerByUsername(entry) != null) 
                {
                Console.WriteLine("Username is taken, try again.");
                return CreateUsername(); 
                }
            return entry;
            }
        private string CreatePassword()
            {
            string entry = "";
            int attempts = 0;
            while (entry.Length < 1 || attempts < 4)
                {
                Console.WriteLine($"Enter your Password: ");
                entry = Console.ReadLine();

                if (entry.Length < 1)
                    {
                    Console.WriteLine($"! Error !  Password cant be empty.");
                    }
                if (entry.Length <= 8)
                    {
                    Console.WriteLine($"! Error !  Password too short (at lest 8 chars).");
                    }
                if (attempts < 4)
                    {
                    Console.WriteLine($"! Error !  Too much attempts.");
                    return null;
                    }
                }
            return entry;
            }
        public static string LoginEntery(string title)
            {
            string entry = "";
            int attempts = 0;
            while (entry.Length < 1 || attempts < 4)
                {
                Console.WriteLine($"Enter your {title}: ");
                entry = Console.ReadLine();

                if (entry.Length < 1)
                    {
                    Console.WriteLine($"! Error !  {title} cant be empty.");
                    }
                if (entry.Length <= 8)
                    {
                    Console.WriteLine($"! Error !  {title} too short (at lest 8 chars).");
                    }
                if (attempts < 4)
                    {
                    Console.WriteLine($"! Error !  Too much attempts.");
                    return null;
                    }
                }
            return entry;
            }

        }
    }
