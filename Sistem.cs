using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace csharp_biblioteca
{
    internal class Sistem
    {
        string connect = "Data Source=localhost;Initial Catalog=biblioteca-db;Integrated Security=True";
        public void AddUtente()
        {
            Biblioteca uno = new Biblioteca();
            User nuovo = uno.NewUser();

            using (SqlConnection connessione = new SqlConnection("Data Source=localhost;Initial Catalog=biblioteca-db;Integrated Security=True"))
            {
                try
                {
                    connessione.Open();
                    //using (SqlCommand cmd = connessione.CreateCommand())
                    using (SqlTransaction trans = connessione.BeginTransaction())
                    {
                        //cmd.Transaction = trans;
                        //cmd.Connection = connessione;
                        try
                        {
                            string query = "INSERT INTO Utente (nome, cognome, email, password) VALUES (@nome, @cognome, @email, @password)";
                            SqlCommand cmd = new SqlCommand(query, connessione);
                            cmd.Parameters.Add(new SqlParameter("@nome", nuovo.name));
                            cmd.Parameters.Add(new SqlParameter("@cognome", nuovo.surname));
                            cmd.Parameters.Add(new SqlParameter("@email", nuovo.email));
                            cmd.Parameters.Add(new SqlParameter("@password", nuovo.password));

                            cmd.Transaction = trans;
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            trans.Rollback();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                connessione.Close();
            }
        }

        public bool LogUtente()
        {
            bool isLogged = false;

            Console.WriteLine("Inserisci nome per effettuare il login");
            string logUser = Console.ReadLine();

            Console.WriteLine("Inserisci la password per effettuare il login");
            string pwUser = Console.ReadLine();

            using (SqlConnection connessione = new SqlConnection("Data Source=localhost;Initial Catalog=biblioteca-db;Integrated Security=True"))
            {
                try
                {
                    connessione.Open();
                    string query = "SELECT nome, password FROM Utente WHERE nome = '" + logUser + "' AND password = '" + pwUser + "';";
                    SqlCommand cmd = connessione.CreateCommand();
                    
                    cmd.Connection = connessione;
                    cmd.CommandText = query;
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        if (reader.Read() == true)
                        {
                            Console.WriteLine($"Ciao {logUser}, accesso effettuato!");
                            isLogged = true;
                        }
                        else
                        {
                            Console.WriteLine("Utente inesistente!");
                            isLogged = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                connessione.Close();
            }
            return isLogged;
        }

        public void CercaLibro()
        {
            Console.WriteLine("Inserisci il titolo o l'autore del libro da cercare");
            string daCercare = Console.ReadLine();

            using (SqlConnection connessione = new SqlConnection(this.connect))
            {
                try
                {
                    connessione.Open();
                    string query = "SELECT * FROM Libri WHERE titolo = '" + daCercare + "' OR autore = '" + daCercare + "';";
                    SqlCommand cmd = connessione.CreateCommand();

                    cmd.Connection = connessione;
                    cmd.CommandText = query;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() == true)
                        {
                            Console.WriteLine("Libri trovati:");
                            
                        }
                        else
                        {
                            Console.WriteLine("Spiacenti, libri non trovati");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
