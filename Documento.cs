using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Documento
    {
        public string title = "";
        public int year;
        public string genre = "";
        public string author = "";
        public string position = "";
        public bool rent = false;

        public Documento(string title, int year, string genre, string author, string position, bool rent)
        {
            this.title = title;
            this.year = year;
            this.genre = genre;
            this.author = author;
            this.position = position;
            this.rent = rent;
        }

       
    }
}
