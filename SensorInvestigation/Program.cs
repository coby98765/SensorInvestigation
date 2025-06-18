using SensorInvestigation.models;
using SensorInvestigation.DB;



namespace Sensor
    {
    class Program
        {
        static void Main()
            {
            //DB Connection
            MySQLData DBConnection = MySQLData.Instance;
            DBConnection.Setup();
            //Service
            PlayerService playerService = new(DBConnection);

            //Test
            Test test = new(playerService);
            }
        }
    }