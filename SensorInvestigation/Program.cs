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

            Factory factory = new();
            Agent agent = factory.CreateAgent();
            agent.Printer();
            List<string> sensors = new(){ "basic", "basic"};
            agent.SensorList = sensors;
            Console.WriteLine(agent.Activate());
            }
        }
    }