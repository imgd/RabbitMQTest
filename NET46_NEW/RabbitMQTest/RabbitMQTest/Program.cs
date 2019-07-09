using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQPush
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("生产已启动...");
            //Console.WriteLine("请输入消息：");
            Snowflake64.InitData(9, 1);
            var push = new QueuePush();
            push.Run();

            Console.ReadLine();
        }
    }
}
