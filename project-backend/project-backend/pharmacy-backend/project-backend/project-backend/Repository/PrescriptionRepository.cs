using Npgsql;
using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Repository
{
    public class PrescriptionRepository
    {

        private const string CONNECTION_STRING = "User ID =postgres;Password=postgres;Server=localhost;Port=8080;Database=psw1;";
        private const string TABLE_NAME = "prescription";

        private NpgsqlConnection connection;
        public PrescriptionRepository()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        private static Prescription ReadPrescription(NpgsqlDataReader reader)
        {
            int? id = reader["id"] as int?;
            int? patientId = reader["patientId"] as int?;
            int? doctorId = reader["doctorId"] as int?;
            string drug = reader["drug"] as string;
            string usage = reader["usage"] as string;

            Prescription prescription = new Prescription
            {
                Id=id.Value,
                PatientId=patientId.Value,
                DoctorId=doctorId.Value,
                Drug=drug,
                Usage=usage
            };
            return prescription;
        }

        public async Task<Prescription> Get(int id)
        {
            string commandText = $"SELECT * FROM {TABLE_NAME} WHERE id = @id";
            await using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("id", id);

                await using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                    {
                        Prescription prescription = ReadPrescription(reader);
                        return prescription;
                    }
            }
            return null;
        }


    }
}
