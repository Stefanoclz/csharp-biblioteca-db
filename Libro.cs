using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Libro : Documento
    {
        public string isbn = "";
        public int pages;

        public Libro(string isbn, int pages, string title, int year, string genre, string author, string position, bool rent) : base(title, year, genre, author, position, rent)
        {
            this.isbn = isbn;
            this.pages = pages;
        }
    }
}
