using MySql.Data.MySqlClient;
using SensorInvestigation.DB;
using SensorInvestigation.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace SensorInvestigation.models
    {
    internal class PlayerService
        {
        private MySQLData _sqlData;
        public PlayerService(MySQLData connData)
            {
            _sqlData = connData;
            }

        //Player Formatter
        private Player PlayerFormatter(MySqlDataReader data)
            {
            int id = data.GetInt32("id");
            string firstName = data.GetString("first_name");
            string lastName = data.GetString("last_name");
            string username = data.GetString("user_name");
            string pw = data.GetString("password");
            int level = data.GetInt32("level");

            Player newPlayer = new(username, pw, firstName, lastName, level, id);
            return newPlayer;
            }

        //CRUD
        //Create
        public Player CreatePlayer(Player player)
            {
            string query = @"INSERT INTO people
                           (user_name,password,first_name,last_name,level)
                            VALUES(@user_name,@password,@first_name,@last_name,@level);" +
                            "SELECT * FROM people WHERE people.id = LAST_INSERT_ID();";
            MySqlCommand cmd = new MySqlCommand(query, _sqlData.GetConnection());
            MySqlDataReader reader = null;

            try
                {
                cmd.Parameters.AddWithValue("@user_name", player.UserName);
                cmd.Parameters.AddWithValue("@password", player.GetPassword("root"));
                cmd.Parameters.AddWithValue("@first_name", player.FirstName);
                cmd.Parameters.AddWithValue("@last_name", player.LastName);
                cmd.Parameters.AddWithValue("@level", player.Level);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                    {
                    player = PlayerFormatter(reader);
                    }
                Console.WriteLine($"Player {player.ID} Added.");
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex.Message);
                return null;
                }
            finally
                {
                _sqlData.CloseConnection();
                }
            return player;
            }
        
        //Read
        public Player GetPlayerByID(int id)
            {
            Player player = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            string query = $"SELECT * FROM people WHERE people.id = {id} LIMIT 1;";
            try
                {
                MySqlConnection connection = _sqlData.GetConnection();
                cmd = new MySqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    {
                    player = PlayerFormatter(reader);
                    }
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Error while fetching Player: {ex.Message}");
                throw;
                }
            finally
                {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                _sqlData.CloseConnection();
                }
            return player;
            }

        //Update
        public Player UpdatePlayerLevel(Player player)
            {
            string query = $"UPDATE people SET type = '{player.Level}' WHERE id = {player.ID};";
            MySqlCommand cmd = new MySqlCommand(query, _sqlData.GetConnection());
            MySqlDataReader reader = null;
            try
                {
                reader = cmd.ExecuteReader();

                if (reader.Read())
                    {
                    player = PlayerFormatter(reader);
                    }
                //int x = cmd.ExecuteNonQuery();
                Console.WriteLine("Person Updated.");
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex.Message);
                return null;
                }
            finally
                {
                _sqlData.CloseConnection();
                }
            return player;
            }
        }
    }
