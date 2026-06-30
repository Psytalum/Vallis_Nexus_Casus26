using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Casus_Vallis_Nexus.DataAccess
{
    public class DAL
    {
        // Connectiestring naar de database
        private string connectionString = "Server=VS_WINDOWS11\\SQLEXPRESS;Database=Vallis_Nexus_Casus26;Trusted_Connection=True;TrustServerCertificate=True;";

        public int GetNextRatingnummer()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(MAX(ratingnummer), 0) + 1 FROM dbo.RATINGS";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        // Voegt een de ratings toe aan de RATINGS-tabel.
        public void InsertRating(int ratingnummer, int muziekrating, int consumptierating, int festivalviberating,
            string muziekbeschrijving, string consumptiebeschrijving, string festivalvibebeschrijving)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO dbo.RATINGS 
                    (ratingnummer, muziekrating, consumptierating, festivalviberating, 
                     muziekbeschrijving, consumptiebeschrijving, festivalvibebeschrijving) 
                    VALUES 
                    (@ratingnummer, @muziekrating, @consumptierating, @festivalviberating, 
                     @muziekbeschrijving, @consumptiebeschrijving, @festivalvibebeschrijving)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ratingnummer", ratingnummer);
                    cmd.Parameters.AddWithValue("@muziekrating", (object)muziekrating ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@consumptierating", (object)consumptierating ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@festivalviberating", (object)festivalviberating ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@muziekbeschrijving", (object)muziekbeschrijving ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@consumptiebeschrijving", (object)consumptiebeschrijving ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@festivalvibebeschrijving", (object)festivalvibebeschrijving ?? DBNull.Value);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // Hier kun je eigen logging/foutafhandeling toevoegen
                        throw new Exception("Fout bij het invoegen van een rating.", ex);
                    }
                }
            }
        }


        // Voegt een nieuwe ervaring toe aan de ERVARING-tabel.
        
        public void InsertErvaring(int ervaringnummer, string tekst, int? idfestivalkaartje, int? leeftijd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO dbo.ERVARING 
                    (ervaringnummer, tekst, idfestivalkaartje, leeftijd) 
                    VALUES 
                    (@ervaringnummer, @tekst, @idfestivalkaartje, @leeftijd)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ervaringnummer", ervaringnummer);

                    if (tekst == null)
                        cmd.Parameters.AddWithValue("@tekst", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@tekst", tekst);

                    if (idfestivalkaartje == null)
                        cmd.Parameters.AddWithValue("@idfestivalkaartje", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@idfestivalkaartje", idfestivalkaartje);

                    if (leeftijd == null)
                        cmd.Parameters.AddWithValue("@leeftijd", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@leeftijd", leeftijd);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Fout bij het invoegen van een ervaring.", ex);
                    }
                }
            }
        }

        // Koppelt rating en ervaring via de koppeltabel RATINGERVARING
        public void InsertRatingErvaring(int ratingnummer, int ervaringnummer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO dbo.RATINGERVARING 
                    (ratingnummer, ervaringnummer) 
                    VALUES 
                    (@ratingnummer, @ervaringnummer)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ratingnummer", ratingnummer);
                    cmd.Parameters.AddWithValue("@ervaringnummer", ervaringnummer);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Fout bij het koppelen van rating en ervaring.", ex);
                    }


                }
            }
        }
    }
}