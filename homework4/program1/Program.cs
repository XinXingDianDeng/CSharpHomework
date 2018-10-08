using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    public class AlarmClockArgs:EventArgs
    {
        public int Hour { get; set; }
        public int Min { get; set; }
        public int Sec { get; set; }
    }

    public delegate void AlarmClock(object sender, AlarmClockArgs e);

    public class Clock
    {
        public event AlarmClock TimeOut;

        public void Ring(int hour,int min,int sec)
        {
            AlarmClockArgs args = new AlarmClockArgs();
            args.Hour = hour;
            args.Min = min;
            args.Sec = sec;
            while(args.Hour != DateTime.Now.Hour || args.Min != DateTime.Now.Minute || args.Sec != DateTime.Now.Second)
            {
                System.Threading.Thread.Sleep(0);
            }
            TimeOut(this, args);
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            clock.TimeOut += new AlarmClock(clock_Alarmclock);
            clock.Ring(20, 45, 55);
        }

        static void clock_Alarmclock(object sender,AlarmClockArgs args)
        {
            Console.WriteLine("Time out!");
        }
    }
}
