using RabbitMQ.Client;
using RabbitMQQueueTest;
using System;
using System.Text;
using System.Threading;

namespace SendClient
{
    class Program
    {
        public
        static void Main(string[] args)
        {
            Console.WriteLine("生产者已启用.");
            Console.WriteLine("请输入消息：");

            var push = new QueuePush();
            push.Run();

            Console.ReadLine();
        }
    }
}
