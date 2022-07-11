// See https://aka.ms/new-console-template for more information

using csharp_biblioteca;

Console.WriteLine("Menu Biblioteca");
Console.WriteLine("1. Registrati");
Console.WriteLine("2. Login");

int scelta1 = Int32.Parse(Console.ReadLine());

if(scelta1 == 1)
{
    Biblioteca uno = new Biblioteca();
    uno.NewUser();
} else if(scelta1 == 2)
{
    Console.WriteLine("Inserisci nome utente per effettuare il login");
    string logUser = Console.ReadLine();


    Console.WriteLine("Inserisci password utente per effettuare il login");
    string pwUser = Console.ReadLine();

    bool test = new Biblioteca().CheckUser(logUser, pwUser);

    if(test == true)
    {
        Console.WriteLine("Accesso effettuato!");
    }
    else
    {
        Console.WriteLine("Utente non trovato");
    }
}

Console.WriteLine("Accesso effettuato, cosa vuoi fare?");
Console.WriteLine("1. Cerca Libro");
Console.WriteLine("2. Cerca Dvd");
int scelta2 = Int32.Parse(Console.ReadLine());

if(scelta2 == 1)
{
    Console.WriteLine("Inserisci il titolo o l'autore del libro da cercare:");
    string cercaLibro = Console.ReadLine();

    bool check = new Liste().CheckBook(cercaLibro);

    if(check == true)
    {
        Console.WriteLine("Libro trovato!");

        Console.WriteLine("Menu elemento:");
        Console.WriteLine("1. dettagli");
        Console.WriteLine("2. Richiedi prestito");
        int scelta3 = Int32.Parse(Console.ReadLine());

        if(scelta3 == 1)
        {
            string detail = new Liste().DetailBook(cercaLibro);
            Console.WriteLine(detail);
        } else if (scelta3 == 2)
        {
            Console.WriteLine("Percorso non ancora programmato");
        }
    } else
    {
        Console.WriteLine("Spiacenti, libro non presente");
    }

} else if( scelta2 == 2)
{
    Console.WriteLine("Inserisci il titolo o il regista del dvd da cercare:");
    string cercaDvd = Console.ReadLine();

    bool check = new Liste().CheckDvd(cercaDvd);

    if (check == true)
    {
        Console.WriteLine("Dvd trovato!");

        Console.WriteLine("Menu elemento:");
        Console.WriteLine("1. dettagli");
        Console.WriteLine("2. Richiedi prestito");

        int scelta4 = Int32.Parse(Console.ReadLine());

        if (scelta4 == 1)
        {
            string detail = new Liste().DetailDvd(cercaDvd);
            Console.WriteLine(detail);
        }
        else if (scelta4 == 2)
        {
            Console.WriteLine("Percorso non ancora programmato");
        }

    } else
    {
        Console.WriteLine("Spiacenti, dvd non trovato");
    }
}


