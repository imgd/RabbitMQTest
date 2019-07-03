using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQQueueTest;
using System;
using System.Text;
using System.Threading;

namespace ReceiveClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("消费者客户端已启动,正在分配线程消费...");
            var thredCount = 10;
            for (int i = 0; i < thredCount; i++)
            {
                ThreadPool.QueueUserWorkItem((object state) =>
                {
                    var sets = Convert.ToInt32(state);
                    Console.WriteLine($"线程{sets}已启动消费者模式.");

                    var receive = new QueueReceive(sets);
                    receive.Run();

                },i);
            }

            Console.ReadLine();
        }
    }
}
