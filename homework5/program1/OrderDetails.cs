using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class OrderDetails
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public void SetDetails(string name, int count, double price)
        {

            Name = name;
            Count = count;
            Price = price;

        }


    }
}
