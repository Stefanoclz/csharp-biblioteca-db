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
    }
}
