using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int n1 = 0, n2 = 0;
            Console.Write("Please input an int:");
            s = Console.ReadLine();
            n1 = Int32.Parse(s);
            Console.Write("Please input another int:");
            s = Console.ReadLine();
            n2 = Int32.Parse(s);
            Console.WriteLine("You have entered: {0} and {1}", n1, n2);
            Console.WriteLine("Their product is:" + (n1*n2));
        }
    }
}
