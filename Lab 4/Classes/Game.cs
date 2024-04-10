using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Classes
{
    public class Game : Product
    {
        public string? Platform { get; set; }

        public Game(int id, string name, decimal price, int quantity, string platform)
            : base(id, name, price, quantity)
        {
            Platform = platform;
        }

    }
}
