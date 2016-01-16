using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buddhika.Google.Blogger.util;

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
        }
    }
}
