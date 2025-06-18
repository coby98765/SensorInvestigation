using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorInvestigation.Models
    {
    internal class Player
        {
        public int ID { get; private set; }
        public string UserName { get; private set; }
        private string _password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Level { get; private set; }

        public Player(string username, string password,string firstN, string lastN, int level=0, int id = 0)
            {
            ID = id;
            UserName = username;
            _password = password;
            FirstName = firstN;
            LastName = lastN;
            Level = level;
            }

        public bool Login(string pw)
            {
            if(pw == _password)
                {
                return true;
                }
            else
                {
                Console.WriteLine("Password dose not match.");
                return false;
                }
            }

        public void LevelUp() { Level++; }
        }
    }
