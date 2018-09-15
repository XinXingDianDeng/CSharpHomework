using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input an int:");
            String s = Console.ReadLine();
            int n = Int32.Parse(s);
            int[] a = new int[n];
            int pro = 1;
            Console.WriteLine("Its prime factors are:" );
            for (int i = 2;i<n+1;i++)
            {
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                        goto outer;
                }
                if(n % i == 0)
                {
                    Console.WriteLine(i);
                }
                outer:;
            }
            
        }
    }
}
