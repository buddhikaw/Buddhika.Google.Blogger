using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buddhika.Google.Blogger.util;
using System.IO.Ports;

namespace Buddhika.Google.Blogger.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            util.Blogger access = new util.Blogger();
            Task task = new Task(access.Authentication);
            task.Start();
            task.Wait();
            access.ServiceOpen();
            long totalPageViews = access.GetPageViews();
            System.Console.WriteLine("total Page Views" + totalPageViews);

            using (SerialPort ardo = new SerialPort())
            {
                ardo.PortName = "COM3";
                ardo.BaudRate = 9600;
                ardo.Open();
                ardo.Write(totalPageViews.ToString()+"\n");
            }
        }
    }
}
