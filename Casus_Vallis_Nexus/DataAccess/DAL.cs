using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Casus_Vallis_Nexus.DataAccess
{
    class DAL
    {
        // Connectiestring naar de database
        private string connectionString = "Server=VS_WINDOWS11\\SQLEXPRESS;Database=Vallis_Nexus_Casus26;Trusted_Connection=True;TrustServerCertificate=True;";

        public void InsertRating(decimal rating)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Rating (Muziekrating) VALUES (@rating)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@rating", rating);
                    cmd.ExecuteNonQuery();
                }
            }
        }




    }
}