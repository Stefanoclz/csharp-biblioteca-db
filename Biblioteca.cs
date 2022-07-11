using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Biblioteca
    {
        public List<User> listaUtenti = new List<User>();
        public Biblioteca()
        {
            listaUtenti.Add(new User("Simone", "Garri", "simogar@email.it", "sim323", "3315265874"));
            listaUtenti.Add(new User("Luca", "Lillo", "lucali@email.it", "sfadfas3", "3478596541"));
            listaUtenti.Add(new User("Rassell", "Crow", "crow@email.it", "crow3", "331525252"));
        }

        public void NewUser()
        {
            Console.WriteLine("inserisci nome");
            string nome = Console.ReadLine();

            Console.WriteLine("inserisci cognome");
            string cognome = Console.ReadLine();

            Console.WriteLine("inserisci password");
            string password = Console.ReadLine();

            Console.WriteLine("inserisci email");
            string email = Console.ReadLine();

            Console.WriteLine("inserisci telefono");
            string telefono = Console.ReadLine();

            User utente = new User(nome, cognome, email, password, telefono);

            if (utente.isLoggedIn == true)
            {
                Console.WriteLine("Utente registrato con successo!");
                listaUtenti.Add(utente);
            }
            else
            {
                Console.WriteLine("Dati inseriti errati");
            }

            foreach (User user in listaUtenti)
            {
                Console.WriteLine(user.ToString());
            }
        }

        public bool CheckUser(string logName, string logPassword)
        {
            bool check = false;
            foreach (User user in listaUtenti)
            {
                if(user.name == logName && user.password == logPassword)
                {
                    check = true;
                    break;
                }
                else
                {
                    check =false;
                }
            }
            return check;
        }
    }
}
