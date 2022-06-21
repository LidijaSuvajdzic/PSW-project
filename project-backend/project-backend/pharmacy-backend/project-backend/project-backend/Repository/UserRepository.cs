using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Repository
{
    public class UserRepository
    {

        private const string CONNECTION_STRING = "User ID =postgres;Password=postgres;Server=localhost;Port=8080;Database=psw1;";
        private const string TABLE_NAME = "users";

        private NpgsqlConnection connection;
        public UserRepository()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        private static User ReadUser(NpgsqlDataReader reader)
        {
            int? userid = reader["userid"] as int?;
            string firstname = reader["firstname"] as string;
            string lastname = reader["lastname"] as string;
            string email = reader["email"] as string;
            string password = reader["password"] as string;
            int? healthcardnumber = reader["healthcardnumber"] as int?;
            string role = reader["role"] as string;
            int? penals = reader["penals"] as int?;

            User game = new User
            {
                UserId = userid.Value,
                Firstname = firstname,
                Lastname = lastname,
                Email=email,
                Passwordd=password,
                HealthCardNumber = healthcardnumber.Value,
                Role = role,
                Penals=penals.Value

            };
            return game;
        }

        public async Task<User> Get(int id)
        {
            string commandText = $"SELECT * FROM {TABLE_NAME} WHERE userid = @id";
            await using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("id", id);

                await using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                    {
                        User game = ReadUser(reader);
                        return game;
                    }
            }
            return null;
        }






    }
}
