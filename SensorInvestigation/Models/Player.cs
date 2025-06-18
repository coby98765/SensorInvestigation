using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace SensorInvestigation.models
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

        public string GetPassword(string key) 
            { 
            if(key == "root")
                {
                return _password;
                }
            else
                {
                return null;
                }
            }
        public void Print()
            {
            Console.WriteLine(

                "\n-----------------------------\n" +
                $"({ID}) {UserName}\n" +
                $"\t{FirstName} {LastName}\n" +
                $"\tLevel: {Level}\n" +
                $"\tPassword: {_password}" +
                "\n-----------------------------\n"
                );
            }
        }
    }
