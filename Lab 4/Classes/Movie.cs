using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Classes
{
    public class Movie : Product
    {
        public string Format { get; set; }
        public string Playtime { get; set; }

        public Movie(int id, string name, decimal price, int quantity, string format, string playtime)
            : base(id, name, price, quantity)
        {
            Format = format;
            Playtime = playtime;
        }
    }
}
