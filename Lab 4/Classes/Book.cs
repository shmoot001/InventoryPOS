using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Classes
{
    public class Book : Product
    {

        public string Author { get; set; }
        public string Genre { get; set; }
        public string? Format { get; set; }
        public string? Language { get; set; }

        public Book(int id, string name, decimal price, int quantity, string author, string genre, string format, string language)
            : base(id, name, price, quantity)
        {
            Author = author;
            Genre = genre;
            Format = format;
            Language = language;
        }


    }
}
