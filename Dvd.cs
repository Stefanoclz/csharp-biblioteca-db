using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Dvd : Documento
    {
        public int serial;
        public int duration;



        public Dvd(int serial, int duration, string title, int year, string genre, string author, string position, bool rent) : base(title, year, genre, author, position, rent)
        {
            this.serial = serial;
            this.duration = duration;
        }
    }
}
