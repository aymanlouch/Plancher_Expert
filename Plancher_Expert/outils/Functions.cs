using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plancher_Expert.Classes;
using System.Data.SqlClient;
using System.Net;

namespace Plancher_Expert.outils
{
    public class Functions
    {
        public static List <Fourniture> getFourniture()
        {
            List<Fourniture> fournitureList = new List<Fourniture>();

            try
            {
                string connexionString = "Data Source=.\\sqlexpress;Initial Catalog=plancher_expert;Integrated Security=True";
                using (SqlConnection connexion = new SqlConnection(connexionString))
                {
                    connexion.Open();
                    string sqlQuery = "select * from Fourniture";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connexion))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {   

                                Fourniture f = new Fourniture();

                                f.Id = reader.GetInt32(0);
                                f.FloorType = reader.GetString(1);
                                f.MaterialRate = (double)reader.GetSqlDouble(2);
                                f.LaborRate = (double)reader.GetSqlDouble(3);
                                f.nomID = reader.GetString(5);
                                f.Description = reader.GetString(6);

                                fournitureList.Add(f);
                            }
                        }
                    }
                }
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);

            }
            Console.WriteLine(fournitureList);
            return fournitureList;
        }

            
        public static Fourniture getFournitureById(int IdP)
        {
            Fourniture f = new Fourniture();
            try
            {
                string connexionString = "Data Source=.\\sqlexpress;Initial Catalog=plancher_expert;Integrated Security=True";
                using (SqlConnection connexion = new SqlConnection(connexionString))
                {
                    connexion.Open();
                    string sqlQuery = "SELECT * FROM Fourniture where Id='" + IdP + "';";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connexion))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                f.Id = reader.GetInt32(0);
                                f.FloorType = reader.GetString(1);
                                f.LaborRate = (float)reader.GetSqlDouble(2);
                                f.MaterialRate = (float)reader.GetSqlDouble(3);
                                f.nomID = reader.GetString(5);
                                f.Description = reader.GetString(6);

                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return f;
        }



        public static bool addToFactureTable(
         int IdFourniture,
         double Area,
         double TotalCost,
         string nomC,
         string prenomC,
         string addressC,
         string telC,
         double Length,
         double Width)
        {
            try
            {
                string connexionString = "Data Source=.\\sqlexpress;Initial Catalog=plancher_expert;Integrated Security=True";
                using (SqlConnection connexion = new SqlConnection(connexionString))
                {
                    connexion.Open();
                    string sqlQuery = "INSERT INTO facture(IdFourniture,Area,TotalCost,nomC,prenomC,addressC,telC,Length,Width) values(@IdFourniture,@Area,@TotalCost,@nomC,@prenomC,@addressC,@telC,@Length,@Width);";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connexion))
                    {
                        command.Parameters.AddWithValue("@IdFourniture", IdFourniture);
                        command.Parameters.AddWithValue("@Area", Area);
                        command.Parameters.AddWithValue("@TotalCost", TotalCost);
                        command.Parameters.AddWithValue("@nomC", nomC);
                        command.Parameters.AddWithValue("@prenomC", prenomC);
                        command.Parameters.AddWithValue("@addressC", addressC);
                        command.Parameters.AddWithValue("@telC", telC);
                        command.Parameters.AddWithValue("@Length", Length);
                        command.Parameters.AddWithValue("@Width", Width);
                        command.ExecuteNonQuery();
                        Console.WriteLine("Facture inserted to database");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }


        public static bool updateFourniture(int IdP, double LaborRate, double MaterialRate)
        {
            try
            {
                string connexionString = "Data Source=.\\sqlexpress;Initial Catalog=plancher_expert;Integrated Security=True";
                using (SqlConnection connexion = new SqlConnection(connexionString))
                {
                    connexion.Open();
                    string sqlQuery = "UPDATE Fourniture SET LaborRate = @LaborRate, MaterialRate = @MaterialRate WHERE Id = @IdP;";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connexion))
                    {
                        command.Parameters.AddWithValue("@IdP", IdP);
                        command.Parameters.AddWithValue("@LaborRate", LaborRate);
                        command.Parameters.AddWithValue("@MaterialRate", MaterialRate);

                        Console.WriteLine("Requete SQL: " + sqlQuery);

                        command.ExecuteNonQuery();
                        Console.WriteLine("Table mise a jour");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }



        public static bool deleteFourniture(int IdP)
        {
            try
            {
                string connexionString = "Data Source=.\\sqlexpress;Initial Catalog=plancher_expert;Integrated Security=True";
                using (SqlConnection connexion = new SqlConnection(connexionString))
                {
                    connexion.Open();
                    string sqlQuery = "DELETE FROM Fourniture WHERE Id=@IdP;";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connexion))
                    {
                        command.Parameters.AddWithValue("@IdP", IdP);
                       
                        Console.WriteLine("Requete SQL: " + sqlQuery);

                        Console.WriteLine("IdP a supprimer ",IdP);

                        command.ExecuteNonQuery();

                        Console.WriteLine("Table mise a jour");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
            return true;
        }

        public static bool addFourniture(string FloorType, double MaterialRate, double LaborRate, string nomID, string Description)
        {

            try
            {
                string connexionString = "Data Source=.\\sqlexpress;Initial Catalog=plancher_expert;Integrated Security=True";
                using (SqlConnection connexion = new SqlConnection(connexionString))
                {
                    connexion.Open();
                    string sqlQuery = "INSERT INTO Fourniture (FloorType, MaterialRate, LaborRate, Image, nomID, Description) VALUES (@FloorType, @MaterialRate, @LaborRate, , @nomID, @Description)";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connexion))
                    {
                        command.Parameters.AddWithValue("@FloorType", FloorType);
                        command.Parameters.AddWithValue("@MaterialRate", MaterialRate);
                        command.Parameters.AddWithValue("@LaborRate", LaborRate);
                        command.Parameters.AddWithValue("@nomID", nomID);
                        command.Parameters.AddWithValue("@Description", Description);

                        Console.WriteLine("Requete SQL: " + sqlQuery);

            

                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;

            }
            
            return true;
        }
    }
}
