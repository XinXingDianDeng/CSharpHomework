using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace program2
{
    public class OrderDetails
    {
        [Key]
        public string ONum { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public OrderDetails()
        {
            ONum = Guid.NewGuid().ToString();
        }
        public OrderDetails(string onum,string name, int count, double price)
        {
            ONum = onum;
            Name = name;
            Count = count;
            Price = price;

        }


    }
}
