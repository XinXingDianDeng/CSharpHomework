using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    //抽象图形类
    public abstract class Figure
    {
        public virtual void Display()
        {
            Console.WriteLine("创建图形");
        }
        public virtual void Area()
        {
            Console.WriteLine("输出面积");
        }
    }
    //三角形类
    public class Triangle:Figure
    {
        private int myBase;
        private int myHeight;
        public Triangle()
        {
            Console.Write("请输入底边长：");
            myBase = Int32.Parse(Console.ReadLine());
            Console.Write("请输入高：");
            myHeight = Int32.Parse(Console.ReadLine());
        }
        public override void Display()
        {
            Console.WriteLine("创建三角形");
        }
        public override void Area()
        {
            Console.WriteLine("三角形面积为：" + 0.5 * myBase * myHeight);
        }
    }
    //圆类
    public class Circle:Figure
    {
        private int myRadius;
        public Circle()
        {
            Console.Write("请输入半径：");
            myRadius = Int32.Parse(Console.ReadLine());
        }
        public override void Display()
        {
            Console.WriteLine("创建圆");
        }
        public override void Area()
        {
            Console.WriteLine("圆面积为：" + myRadius * myRadius * System.Math.PI);
        }
    }
    //正方形类
    public class Square:Figure
    {
        private int mySide;
        public Square()
        {
            Console.Write("请输入边长：");
            mySide = Int32.Parse(Console.ReadLine());
        }
        public override void Display()
        {
            Console.WriteLine("创建正方形");
        }
        public override void Area()
        {
            Console.WriteLine("正方形面积为：" + mySide * mySide);
        }
    }
    //长方形类
    public class Rectangle:Figure
    {
        private int myWidth;
        private int myHeight;
        public Rectangle()
        {
            Console.Write("请输入宽：");
            myWidth = Int32.Parse(Console.ReadLine());
            Console.Write("请输入长：");
            myHeight = Int32.Parse(Console.ReadLine());
        }
        public override void Display()
        {
            Console.WriteLine("创建长方形");
        }
        public override void Area()
        {
            Console.WriteLine("长方形面积为：" + myWidth * myHeight);
        }
    }
    //工厂类
    public class FigureFactory
    {
        public static Figure GetFigure(String type)
        {
            Figure figure = null;
            if(type.Equals("Triangle"))
            {
                figure = new Triangle();
            }
            else if(type.Equals("Circle"))
            {
                figure = new Circle();
            }
            else if(type.Equals("Square"))
            {
                figure = new Square();
            }
            else if(type.Equals("Rectangle"))
            {
                figure = new Rectangle();
            }
            return figure;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Figure figure;
            figure = FigureFactory.GetFigure("Rectangle");
            figure.Display();
            figure.Area();
        }
    }
}
