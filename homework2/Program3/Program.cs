using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** 求2--100之间的素数 ******");
            int n = 0;
            int[] a = new int[99];
            int k = 0;
            int L = 0;
            for (int i = 2; i < 101; i++)
            {
                a[k] = i;
                k++;
            }
            for (int i = 2;i<101;i++)
            {
                int m = 0;int b = 0;
                for(int j = 2;j < 101;j++)
                {
                    if (a[m] % i != 0 || a[m]/i == 1)
                    {
                        a[b] = a[m];
                        b++;L = b;
                    }
                    m++; 
                }
            }
            for (int i = 0; i < L; i++)
            {
                if (a[i] < a[i + 1])
                {
                    Console.Write("    " + a[i]);
                    n++;
                    if (n % 7 == 0)
                        Console.WriteLine();
                }
                else
                {
                    Console.Write("   " + a[i]);
                    break;
                }
            }
        }
    }
}
