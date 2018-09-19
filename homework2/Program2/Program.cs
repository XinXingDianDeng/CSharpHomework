using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 3, 5, 6, 25, 14, 7, 5, 10, 23 };
            int max = a[0], min = a[0], sum = 0;
            foreach(int i in a)
            {
                if(max < i)
                    max = i;
                if (min > i)
                    min = i;
                sum += i;
            }
            double avg = sum / (double)a.Length;

            Console.WriteLine("最大值是：" + max);
            Console.WriteLine("最小值是：" + min);
            Console.WriteLine("平均值是：" + avg);
            Console.WriteLine("元素之和：" + sum);
        }
    }
}
